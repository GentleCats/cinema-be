using cinema_be.Entities;
using cinema_be.Models.DTO;
using cinema_be.Models.DTOs;

namespace cinema_be.Interfaces
{
    public interface IMovieService
    {
        //List<Movie> GetMovies();
        public List<MovieDto> GetMovies();

        Movie? GetMovieById(int id);
        void Create(CreateMovieDto movie);
        void Update(Movie movie);
        void Delete(int id);
        void UpdateMovie(int id, UpdateMovieDto movieDto);
        public List<MovieDto> GetMyFilms(int userId);
        public List<MovieDto> GetSortedMovies(string sortType, string genre);
    }
}
