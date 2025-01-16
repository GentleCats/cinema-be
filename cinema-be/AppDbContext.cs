using Microsoft.EntityFrameworkCore;

namespace cinema_be
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
    }
}
