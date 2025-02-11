using cinema_be.Entities;
using cinema_be.Models.DTOs;
namespace cinema_be.Interfaces
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetTickets();
        List<Ticket> GetTicketsBySessionId(int id);
        Ticket GetTicketById(int id);
        void Create(CreateTicketDto ticketDto);
        void Delete(int id);
    }
}