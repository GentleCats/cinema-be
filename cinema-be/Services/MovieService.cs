using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Models.DTOs;
using AutoMapper;
using cinema_be.Models.DTO;

namespace cinema_be.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> movieRepo;
        private readonly IMapper _mapper;

        public MovieService(IRepository<Movie> movieRepo, IMapper mapper)
        {
            this.movieRepo = movieRepo;
            _mapper = mapper;
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
            var movie = movieRepo.Get(filter: b => b.TmdbId == id).FirstOrDefault();
            return movie;
        }

        public List<Movie> GetMovies()
        {
            return movieRepo.Get().ToList();
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

    }
}
