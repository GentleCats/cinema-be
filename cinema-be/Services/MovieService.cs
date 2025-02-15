using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Models.DTOs;
using AutoMapper;
using cinema_be.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;

namespace cinema_be.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepo;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        private readonly IRepository<Ticket> _ticketRepo;
        private readonly IRepository<Session> _sessionRepo;

        public MovieService(IRepository<Movie> movieRepo,IRepository<Ticket> ticketRepo,IRepository<Session> sessionRepo, IMapper mapper,HttpClient httpClient)
        {
            _movieRepo = movieRepo;
            _ticketRepo = ticketRepo;
            _sessionRepo = sessionRepo;
            _mapper = mapper;
            _httpClient = httpClient;
        }
        public List<MovieDto> GetMyFilms(int userId)
        {
            var myTickets =  _ticketRepo.Get(filter: t => t.UserId == userId).ToList();
            var sessionIds = myTickets.Select(ticket => ticket.SessionId).Distinct().ToList();
            var sessions = _sessionRepo.Get(filter: s => sessionIds.Contains(s.Id)).ToList();
            var movieIds = sessions.Select(session => session.MovieId).Distinct().ToList();
            var watchedMovies = _movieRepo.Get(m => movieIds.Contains(m.Id), includeProperties: new string[] { "Cast" }).ToList();

            List<MovieDto> availableMovies = GetMovies().Where(m => !watchedMovies.Any(w => w.Id == m.Id)).ToList();
            List<MovieDto> recommendedMovies = GetRecommendedMovies(availableMovies,_mapper.Map<List<MovieDto>>(watchedMovies));

            return recommendedMovies;
        }
        public double GetJaccardSimilarity(MovieDto movie1, MovieDto movie2)
        {
            var genres1 = new HashSet<string>(movie1.Genre.Split(", ").Select(g => g.Trim()));
            var genres2 = new HashSet<string>(movie2.Genre.Split(", ").Select(g => g.Trim()));

            var actors1 = new HashSet<string>(movie1.Cast.Select(a => a.Name));
            var actors2 = new HashSet<string>(movie2.Cast.Select(a => a.Name));

            var attributes1 = genres1.Union(actors1);
            var attributes2 = genres2.Union(actors2);

            var intersection = attributes1.Intersect(attributes2).Count();
            var union = attributes1.Union(attributes2).Count();

            return union == 0 ? 0 : (double)intersection / union;
        }
        public List<MovieDto> GetRecommendedMovies(List<MovieDto> availableMovies,List<MovieDto> watchedMovies)
        {
            var similarityScores = new Dictionary<MovieDto, double>();

            foreach (var availableMovie in availableMovies)
            {
                double totalSimilarity = 0;
                Console.WriteLine(totalSimilarity);

                foreach (var watchedMovie in watchedMovies)
                {
                    totalSimilarity += GetJaccardSimilarity(watchedMovie, availableMovie);
                }

                double avgSimilarity = totalSimilarity / watchedMovies.Count;
                similarityScores[availableMovie] = avgSimilarity;
            }

            return similarityScores.OrderByDescending(x => x.Value)
                                .Take(3)
                                .Select(x => x.Key)
                                .ToList();
        }

        public void Create(CreateMovieDto movieDto)
        {
            try
            {
                var movie = _mapper.Map<Movie>(movieDto);
                _movieRepo.Insert(movie);
                _movieRepo.Save();
                Console.WriteLine("Movie added successfully");
            }
            catch (Exception ex) {
                Console.WriteLine($"Error while adding movie:{ex.Message}");
            }
        }

        public void Delete(int id)
        {
            var find = GetMovieById(id);
            if (find == null) return;

            _movieRepo.Delete(find);
            _movieRepo.Save();
        }

        public Movie? GetMovieById(int id)
        {
            if (id < 0) return null;

            var movie = _movieRepo.Get(filter: m => m.TmdbId == id, includeProperties: "Cast").FirstOrDefault();
            
            return movie;
        }


        public List<MovieDto> GetMovies()
        {
            var movies = _movieRepo.Get(includeProperties: new string[] { "Cast" }).ToList();
            return _mapper.Map<List<MovieDto>>(movies);
        }


        public void Update(Movie movie)
        {
            _movieRepo.Update(movie);
            _movieRepo.Save();
        }
        public void UpdateMovie(int id, UpdateMovieDto movieDto)
        {
            var existingMovie = GetMovieById(id);
            if (existingMovie == null)
            {
                Console.WriteLine("Movie not found.");
                return;
            }

            _mapper.Map(movieDto, existingMovie);

            _movieRepo.Update(existingMovie);
            _movieRepo.Save();
            Console.WriteLine("Movie updated successfully.");
        }
        public List<MovieDto> GetSortedMovies(string sortType, string genre)
        {
            //if (string.IsNullOrWhiteSpace(sortType))
            //    return new List<MovieDto>();

            var query = _movieRepo.Get(includeProperties: "Sessions");

            if (!string.IsNullOrWhiteSpace(genre))
            {
                var genreList = genre.Split(',').Select(g => g.Trim()).ToList(); // розділяємо жанри і прибираємо пробіли
                query = query.Where(m => genreList.Any(g => m.Genre.Contains(g, StringComparison.OrdinalIgnoreCase)));
            }

            switch (sortType.ToLower())
            {
                case "date":
                    query = query.OrderBy(m => m.ReleaseDate);
                    break;
                case "duration":
                    query = query.OrderBy(m => m.Duration);
                    break;
                case "sessions":
                    query = query.OrderBy(m => m.Sessions.Min(s => s.StartTime));
                    break;
                default:
                    query = query.OrderBy(m => m.Title);
                    break;
            }

            var movies = query.ToList();
            return _mapper.Map<List<MovieDto>>(movies);
        }
        public class TmdbGenreResponse
        {
            public List<GenreDto> Genres { get; set; } = new List<GenreDto>();
        }
        public async Task<List<GenreDto>> GetGenresFromApi()
        {
            var apiKey = "afebafe01724d35440a9333c385ac134";
            var url = $"https://api.themoviedb.org/3/genre/movie/list?api_key={apiKey}&language=en-US";

            var response = await _httpClient.GetStringAsync(url);
            var tmdbGenreResponse = JsonConvert.DeserializeObject<TmdbGenreResponse>(response);

            return tmdbGenreResponse?.Genres ?? new List<GenreDto>();
        }


    }
}
