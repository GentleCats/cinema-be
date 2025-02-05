using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace cinema_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
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

            _ticketService.Create(ticketDto);
            return CreatedAtAction(nameof(GetById), new { id = _ticketService.GetTickets().Last().Id }, ticketDto);
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
    }
}
