using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Models.DTOs;
using cinema_be.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace cinema_be.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("get-all")]
        public ActionResult<IEnumerable<Ticket>> GetAll()
        {
            var tickets = _ticketService.GetTickets();
            return Ok(tickets);
        }

        [HttpGet("get-by-id/{id}")]
        public ActionResult<Ticket> GetById(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound(new { success = false, message = "Ticket not found" });
            }
            return Ok(ticket);
        }

        [HttpGet("get-by-sessionId/{id}")]
        public ActionResult<IEnumerable<Ticket>> GetTicketsBySessionId(int id)
        {
            var tickets = _ticketService.GetTicketsBySessionId(id);
            return Ok(tickets);
        }

        [Authorize]
        [HttpPost("create")]
        public ActionResult Create([FromBody] CreateTicketDto ticketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                ticketDto.UserId = int.Parse(userId);
                _ticketService.Create(ticketDto);
                return CreatedAtAction(nameof(GetById), new { id = _ticketService.GetTickets().Last().Id }, ticketDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteById(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound(new { success = false, message = "Ticket not found" });
            }

            _ticketService.Delete(id);
            return NoContent();
        }

        // [Authorize]
        [HttpGet("my-sessions")]
        public ActionResult<IEnumerable<object>> GetUserSessions()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { success = false, message = "User ID not found in token" });
            }

            var sessionDetails = _ticketService.GetMySessions(int.Parse(userId));

            return Ok(sessionDetails);
        }

        [HttpGet("my-tickets")]
        public ActionResult<IEnumerable<Ticket>> GetUserTickets()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { success = false, message = "User ID not found in token" });
            }

            var tickets = _ticketService.GetUserTickets(int.Parse(userId));

            return Ok(tickets);
        }
    }
}
