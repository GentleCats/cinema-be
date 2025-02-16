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
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public TicketService(IRepository<Ticket> ticketRepo, IMapper mapper,ISessionService sessionService)
        {
            _ticketRepo = ticketRepo;
            _mapper = mapper;
            _sessionService = sessionService;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _ticketRepo.Get().ToList();
        }

        public Ticket? GetTicketById(int id)
        {
            return _ticketRepo.Get(filter: t => t.Id == id).FirstOrDefault();
        }

        public List<Ticket> GetTicketsBySessionId(int id)
        {
            return _ticketRepo.Get(filter: t => t.SessionId == id).ToList();
        }

        public void Create(CreateTicketDto ticketDto)
        {
            try
            {
                var isTaken = _ticketRepo.Get(filter: t =>
                   t.SessionId == ticketDto.SessionId &&
                   t.Row == ticketDto.Row &&
                   t.Col == ticketDto.Col &&
                   t.Seat == ticketDto.Seat
               ).Any();

                if (isTaken)
                {
                    throw new Exception("This seat is already booked for this session.");
                }
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
        public IEnumerable<Ticket> GetUserTickets(int userId)
        {
            return _ticketRepo.Get(filter: t => t.UserId == userId).ToList();
        }
        public IEnumerable<object> GetMySessions(int userId)
        {
            var tickets = GetUserTickets(userId);
            var sessionIds = tickets.Select(t => t.SessionId).Distinct().ToList();

            var sessionsData = new Dictionary<int, Session>();

            foreach (var sessionId in sessionIds)
            {
                var session = _sessionService.GetSessionById(sessionId);
                if (session != null && !sessionsData.ContainsKey(session.Id))
                {
                    sessionsData.Add(session.Id, session);
                }
            }

            var sessionDetails = tickets
                .GroupBy(t => t.SessionId)
                .Select(g => new
                {
                    Id = g.Key,
                    StartTime = sessionsData[g.Key].StartTime,
                    EndTime = sessionsData[g.Key].EndTime,
                    Price = sessionsData[g.Key].Price,
                    Hall = sessionsData.ContainsKey(g.Key) ? new
                    {
                        sessionsData[g.Key].Hall.Id,
                        sessionsData[g.Key].Hall.Name,
                        sessionsData[g.Key].Hall.Capacity
                    } : null,  
                    Tickets = g.Select(t => new
                    {
                        t.Id,
                        t.BookingTime,
                        t.UserId,
                        t.SessionId,
                        t.Seat,
                        t.Row,
                        t.Col
                    }).ToList()
                })
                .ToList();
            return sessionDetails;
        }
    }
}
