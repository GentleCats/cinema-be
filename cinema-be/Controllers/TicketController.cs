using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace cinema_be.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IHallService _hallService;
        public TicketController(ITicketService ticketService, IHallService hallService)
        {
            _ticketService = ticketService;
            _hallService = hallService;
        }
        [HttpGet("get-all")]
        public ActionResult GetAll()
        {
            var tickets = _ticketService.GetTickets();
            return Ok(tickets);
        }
        [HttpGet("get-by-id/{id}")]
        public ActionResult GetById(int id)
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
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { success = false, errors });
            }
            var hall = _hallService.GetHallById(ticketDto.HallId);
            if (hall == null)
            {
                return BadRequest(new { success = false, message = "Invalid hall ID" });
            }
            if (ticketDto.SeatNumber < 0 || ticketDto.SeatNumber >= hall.Capacity)
            {
                return BadRequest(new { success = false, message = "Invalid seat number" });
            }
            _ticketService.Create(ticketDto);
            return NoContent();
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