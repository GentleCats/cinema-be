using cinema_be.Entities;
using cinema_be.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using cinema_be.Models.DTOs;

namespace cinema_be.Controllers
{
    [Route("api/[controller]")]
    public class HallController : Controller
    {
        private readonly IHallService _hallService;

        public HallController(IHallService hallService)
        {
            _hallService = hallService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("get-all")] 
        public ActionResult GetAll()
        {
            var halls = _hallService.GetHalls();
            return Ok(halls);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("get-by-id/{id}")] 
        public ActionResult GetById(int id)
        {
            var hall = _hallService.GetHallById(id);
            return Ok(hall);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("create")] 
        public ActionResult Create([FromBody] CreateHallDto hallDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { success = false, errors });
            }

            _hallService.Create(hallDto);
            return NoContent();
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteById(int id)
        {
            _hallService.Delete(id);
            return NoContent();
        }
    }
}