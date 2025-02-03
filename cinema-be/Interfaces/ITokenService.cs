using cinema_be.Entities;

namespace cinema_be.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}
