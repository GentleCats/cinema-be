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
        private readonly IRepository<Movie> movieRepo;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public MovieService(IRepository<Movie> movieRepo, IMapper mapper, HttpClient httpClient)
        {
            this.movieRepo = movieRepo;
            _mapper = mapper;
            _httpClient = httpClient;
        }
        public void Create(CreateMovieDto movieDto)
        {
            try
            {
                var movie = _mapper.Map<Movie>(movieDto);
                movieRepo.Insert(movie);
                movieRepo.Save();
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

            movieRepo.Delete(find);
            movieRepo.Save();
        }

        public Movie? GetMovieById(int id)
        {
            if (id < 0) return null;

            var movie = movieRepo.Get(filter: m => m.TmdbId == id, includeProperties: "Cast").FirstOrDefault();
            
            return movie;
        }


        public List<MovieDto> GetMovies()
        {
            var movies = movieRepo.Get(includeProperties: new string[] { "Cast" }).ToList();
            return _mapper.Map<List<MovieDto>>(movies);
        }


        public void Update(Movie movie)
        {
            movieRepo.Update(movie);
            movieRepo.Save();
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

            movieRepo.Update(existingMovie);
            movieRepo.Save();
            Console.WriteLine("Movie updated successfully.");
        }
        public List<MovieDto> GetSortedMovies(string sortType, string genre)
        {
            //if (string.IsNullOrWhiteSpace(sortType))
            //    return new List<MovieDto>();

            var query = movieRepo.Get(includeProperties: "Sessions");

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
