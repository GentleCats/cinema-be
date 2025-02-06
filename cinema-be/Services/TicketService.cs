using System;
using System.Collections.Generic;
using System.Linq;
using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Models.DTOs;
using AutoMapper;

namespace cinema_be.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepo;
        private readonly IMapper _mapper;

        public TicketService(IRepository<Ticket> ticketRepo, IMapper mapper)
        {
            _ticketRepo = ticketRepo;
            _mapper = mapper;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _ticketRepo.Get().ToList();
        }

        public Ticket? GetTicketById(int id)
        {
            return _ticketRepo.Get(filter: t => t.Id == id).FirstOrDefault();
        }

        public void Create(CreateTicketDto ticketDto)
        {
            try
            {
                var ticket = _mapper.Map<Ticket>(ticketDto);
                ticket.BookingTime = DateTime.UtcNow;
                _ticketRepo.Insert(ticket);
                _ticketRepo.Save();
                Console.WriteLine("Ticket added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding ticket: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            var ticket = GetTicketById(id);
            if (ticket == null) return;

            _ticketRepo.Delete(ticket);
            _ticketRepo.Save();
        }
    }
}
