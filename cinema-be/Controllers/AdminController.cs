using cinema_be.Entities;
using cinema_be.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cinema_be.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

    public class AdminController : Controller
    {
        private readonly IMovieService _movieService;

        public AdminController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpPost("create")]
        public ActionResult Create([FromBody] Movie movie)
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

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteById(int id)
        {
            _movieService.Delete(id);
            return NoContent();
        }
    }
}
