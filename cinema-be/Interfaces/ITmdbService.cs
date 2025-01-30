using cinema_be.Entities;
using cinema_be.Models.DTOs;

namespace cinema_be.Interfaces
{
    public interface ITMDBService
    {
        Task<List<Movie>> GetPopularMoviesAsync(int page);
        Task<Movie> GetMovieDetailsAsync(int movieId);
    }
}
