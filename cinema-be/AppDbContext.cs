using cinema_be.Entities;
using Microsoft.EntityFrameworkCore;

namespace cinema_be
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() : base() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }



    }
}
