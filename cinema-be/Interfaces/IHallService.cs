using cinema_be.Entities;
using cinema_be.Models.DTOs;

namespace cinema_be.Interfaces
{
    public interface IHallService
    {
        IEnumerable<Hall> GetHalls();
        Hall GetHallById(int id);
        void Create(CreateHallDto hallDto);
        void Delete(int id);
    }
}
