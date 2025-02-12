using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using cinema_be.Models.DTOs;
using cinema_be.Validators;

namespace cinema_be.Controllers
{
  [Route("api/[controller]")]
  public class SessionController : Controller
  {
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
      _sessionService = sessionService;
    }

    [AllowAnonymous]
    [HttpPost]
        public ActionResult Create([FromBody] CreateSessionDto session)
        {
            var validator = new CreateSessionDtoValidator();
            var validationResult = validator.Validate(session);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, errors });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { success = false, errors });
            }

            _sessionService.Create(session);
            return NoContent();
        }

        [AllowAnonymous]
    [HttpGet]
    public ActionResult GetAll()
    {
      var sessions = _sessionService.GetSessions();
      return Ok(sessions);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
      var session = _sessionService.GetSessionById(id);
      return Ok(session);
    }
    
    [AllowAnonymous]
    [HttpGet("get-by-film-id/{id}")]
    public ActionResult GetSessionByMovieId(int id)
    {
      var session = _sessionService.GetSessionByMovieId(id);
      return Ok(session);
    }

    [AllowAnonymous]
    [HttpDelete("{id}")]
    public ActionResult DeleteById(int id)
    {
      _sessionService.Delete(id);
      return NoContent();
    }
  }
}