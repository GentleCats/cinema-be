using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using cinema_be.Models.DTOs;

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
        [HttpPost("create")]
        public ActionResult Create([FromBody] CreateMovieDto movie)
        {
            if (!ModelState.IsValid)
            {

                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { success = false, errors });
            }

            _movieService.Create(movie);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("get-all")]
        public ActionResult GetAll()
        {
            var movies = _movieService.GetMovies();
            return Ok(movies);
        }

        [AllowAnonymous]
        [HttpGet("get-by-id/{id}")]
        public ActionResult GetById(int id)
        {
            var movies = _movieService.GetMovieById(id);
            return Ok(movies);
        }

        [AllowAnonymous]
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteById(int id)
        {
            _movieService.Delete(id);
            return NoContent();
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
    }
}
