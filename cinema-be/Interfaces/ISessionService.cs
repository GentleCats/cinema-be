using cinema_be.Entities;
using cinema_be.Models.DTOs;

namespace cinema_be.Interfaces
{
    public interface ISessionService
    {
        List<Session> GetSessions();
        List<Session> GetSessionByMovieId(int id);
        Session? GetSessionById(int id);
        void Create(CreateSessionDto createSessionDto);
        void Delete(int id);
    }
}
