using cinema_be.Entities;

namespace cinema_be.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetMovies();

        Movie? GetMovieById(int id);
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(int id);

    }
}
