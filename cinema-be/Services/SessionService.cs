using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Models.DTOs;
using AutoMapper;

namespace cinema_be.Services
{
  public class SessionService : ISessionService
  {
    private readonly IRepository<Session> _sesisonRepo;
    private readonly IMapper _mapper;

    public SessionService(IRepository<Session> sessionRepo, IMapper mapper)
    {
      _sesisonRepo = sessionRepo;
      _mapper = mapper;
    }
    public void Create(CreateSessionDto createSessionDto)
    {
      try{
        var session = _mapper.Map<Session>(createSessionDto);
        _sesisonRepo.Insert(session);
        _sesisonRepo.Save();
        Console.WriteLine("Session added successfully");
      }
      catch (Exception ex){
        Console.WriteLine($"Error while adding session:{ex.Message}");
      }
    }
    public List<Session> GetSessions()
    {
      return _sesisonRepo.Get().ToList();
    }
    public Session? GetSessionById(int id)
    {
      var session = _sesisonRepo.Get(filter: s => s.Id == id, includeProperties: "Hall").FirstOrDefault();
      return session;
    }
    public List<Session> GetSessionByMovieId(int id)
    {
      DateTime now = DateTime.UtcNow;

      return _sesisonRepo.Get(
          filter: s => s.MovieId == id //&& s.Date >= now.Date
      ).AsEnumerable() 
      .OrderByDescending(s => s.Date)
      .ThenByDescending(s => s.StartTime)
      .ToList();
    } 

    public void Delete(int id)
    {
      var session = GetSessionById(id);
      if(session == null) return;

      _sesisonRepo.Delete(session);
      _sesisonRepo.Save();
    }
  } 
}