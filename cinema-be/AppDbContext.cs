using cinema_be.Entities;
using cinema_be.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cinema_be
{
    public class AppDbContext : IdentityDbContext<User, Role, int>

    {
        public AppDbContext() : base() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
       // public DbSet<Booking> Bookings { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedHall();
            modelBuilder.SeedSession();
            // DbInitializer.SeedUser(modelBuilder);
            // DbInitializer.SeedHall(modelBuilder);
            // DbInitializer.SeedSession(modelBuilder);
            // DbInitializer.SeedBooking(modelBuilder);
            // DbInitializer.SeedTicket(modelBuilder);
        }


    }
}
