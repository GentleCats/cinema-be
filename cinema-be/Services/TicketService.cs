using System;
using System.Collections.Generic;
using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Models.DTOs;

namespace cinema_be.Services
{
    public class TicketService : ITicketService
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();

        public IEnumerable<Ticket> GetTickets()
        {
            return _tickets;
        }

        public Ticket GetTicketById(int id)
        {
            return _tickets.Find(t => t.Id == id);
        }

        public void Create(CreateTicketDto ticketDto)
        {
            var ticket = new Ticket
            {
                Id = _tickets.Count + 1, 
                SessionId = ticketDto.SessionId,
                UserId = ticketDto.UserId,
                Seat = ticketDto.Seat,
                Price = ticketDto.Price,
                BookingTime = DateTime.UtcNow
            };
            _tickets.Add(ticket);
        }

        public void Delete(int id)
        {
            var ticket = GetTicketById(id);
            if (ticket != null)
            {
                _tickets.Remove(ticket);
            }
        }
    }
}