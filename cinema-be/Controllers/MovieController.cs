using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using cinema_be.Models.DTOs;
using cinema_be.Models.DTO;

namespace cinema_be.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ITMDBService _tmdbService;

        public MovieController(IMovieService movieService,ITMDBService tmdbService)
        {
            _movieService = movieService;
            _tmdbService = tmdbService;
        }

        
        [AllowAnonymous]
        [HttpGet("get-all")]
        public ActionResult GetAll()
        {
            var movies = _movieService.GetMovies();
            return Ok(movies);
        }

        [AllowAnonymous]
        [HttpGet("get-by-id/{tmdbId}")]
        public ActionResult GetById(int tmdbId)
        {
            var movies = _movieService.GetMovieById(tmdbId);
            return Ok(movies);
        }

        
        [AllowAnonymous]
        [HttpGet("get-popular")]
        public async Task<ActionResult> GetPopular(int page){
            var movies = await _tmdbService.GetPopularMoviesAsync(page);
            return Ok(movies);
        }

        [AllowAnonymous]
        [HttpGet("get-by-tmdb-id")]
        public async Task<ActionResult> GetMovieDetailsAsync(int movieId){
            var movie = await _tmdbService.GetMovieDetailsAsync(movieId);
            return Ok(movie);
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _movieService.UpdateMovie(id, movieDto);
            return Ok("Movie updated successfully.");
        }
        [AllowAnonymous]
        [HttpGet("get-sorted")]
        public ActionResult GetSortedMovies([FromQuery] string sortType)
        {
            var movies = _movieService.GetSortedMovies(sortType);
            Console.WriteLine($"Movies count: {movies.Count}");
            return Ok(movies);
        }


    }
}
