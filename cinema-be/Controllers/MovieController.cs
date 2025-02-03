using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace cinema_be.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
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


       
    }
}
