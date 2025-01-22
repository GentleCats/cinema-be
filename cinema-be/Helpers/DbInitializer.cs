﻿using cinema_be.Entities;
using Microsoft.EntityFrameworkCore;

namespace cinema_be.Helpers
{
    public static class DbInitializer
    {
        public static async Task SeedMovie(AppDbContext context, TmdbService tmdbService)
        {
            var movies = await tmdbService.GetPopularMoviesAsync();

            if (movies == null || !movies.Any()) 
            {
                Console.WriteLine("No movies to seed.");
                return;
            }

            foreach (var movie in movies)
            {
                if (!context.Movies.Any(m => m.Title == movie.Title)) 
                {
                    context.Movies.Add(movie);
                }
            }

            await context.SaveChangesAsync();

        }
        public static void SeedSession(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>().HasData(
                new Session[]
                {
                    new Session()
                    {
                        Id = 1,
                        MovieId = 1,
                        HallId = 1,
                        StartTime = new TimeSpan(19, 55, 0),
                        EndTime = new TimeSpan(21, 45, 0),
                        Date = new DateTime(2025, 1, 18),

                    },
                    new Session()
                    {
                        Id = 2,
                        MovieId = 1,
                        HallId = 1,
                        StartTime = new TimeSpan(19, 55, 0),
                        EndTime = new TimeSpan(21, 45, 0),
                        Date = new DateTime(2025, 1, 19),

                    },
                    new Session()
                    {
                        Id = 3,
                        MovieId = 1,
                        HallId = 1,
                        StartTime = new TimeSpan(19, 55, 0),
                        EndTime = new TimeSpan(21, 45, 0),
                        Date = new DateTime(2025, 1, 20),

                    },
                    new Session()
                    {
                        Id = 4,
                        MovieId = 2,
                        HallId = 2,
                        StartTime = new TimeSpan(10, 10, 0),
                        EndTime = new TimeSpan(12, 00, 0),
                        Date = new DateTime(2025, 1, 18),

                    },
                    new Session()
                    {
                        Id = 5,
                        MovieId = 2,
                        HallId = 2,
                        StartTime = new TimeSpan(16, 20, 0),
                        EndTime = new TimeSpan(18, 10, 0),
                        Date = new DateTime(2025, 1, 18),

                    },
                    new Session()
                    {
                        Id = 6,
                        MovieId = 2,
                        HallId = 2,
                        StartTime = new TimeSpan(10, 10, 0),
                        EndTime = new TimeSpan(12, 00, 0),
                        Date = new DateTime(2025, 1, 19),

                    },
                    new Session()
                    {
                        Id = 7,
                        MovieId = 2,
                        HallId = 2,
                        StartTime = new TimeSpan(16, 20, 0),
                        EndTime = new TimeSpan(18, 10, 0),
                        Date = new DateTime(2025, 1, 19),

                    },
                    new Session()
                    {
                        Id = 8,
                        MovieId = 3,
                        HallId = 3,
                        StartTime = new TimeSpan(20, 10, 0),
                        EndTime = new TimeSpan(22, 10, 0),
                        Date = new DateTime(2025, 1, 18),

                    },
                    new Session()
                    {
                        Id = 9,
                        MovieId = 3,
                        HallId = 3,
                        StartTime = new TimeSpan(20, 10, 0),
                        EndTime = new TimeSpan(22, 10, 0),
                        Date = new DateTime(2025, 1, 19),

                    },
                }
                );
        }
        public static void SeedHall(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>().HasData(
                new Hall[]
                {
                    new Hall(){
                        Id = 1,
                        Name="Альфа",
                        Сapacity = 302
                    },
                    new Hall(){
                        Id = 2,
                        Name="Парадиз",
                        Сapacity = 377
                    },
                    new Hall(){
                        Id = 3,
                        Name="Арена",
                        Сapacity = 346
                    },
                });
        }
        public static void SeedBooking(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Booking>().HasData(
                new Booking[]
                {
                    new Booking()
                    {
                        Id = 1,
                        BookingTime= new DateTime(2025,1,17),
                        SessionId = 1,
                        UserId=1,

                    },
                    new Booking()
                    {
                        Id = 2,
                        BookingTime= new DateTime(2025,1,14),
                        SessionId = 8,
                        UserId=2,

                    },
                    new Booking()
                    {
                        Id = 3,
                        BookingTime= new DateTime(2025,1,15),
                        SessionId = 4,
                        UserId=3,

                    },
                    new Booking()
                    {
                        Id = 4,
                        BookingTime= new DateTime(2025,1,17),
                        SessionId = 3,
                        UserId=3,

                    },
                    new Booking()
                    {
                        Id = 5,
                        BookingTime= new DateTime(2025,1,12),
                        SessionId = 2,
                        UserId=4,

                    },
                    new Booking()
                    {
                        Id = 6,
                        BookingTime= new DateTime(2025,1,10),
                        SessionId = 4,
                        UserId=4,

                    },

                }
            );
                
        }
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User()
                    {
                        Id= 1,
                        UserName ="Sasha Osadets",
                        Email = "osadets@gmail.com",
                        PasswordHash= "Qwerty!",
                        IsAdmin = false
                    },
                    new User()
                    {
                        Id= 2,
                        UserName ="Fedor",
                        Email = "fedor@gmail.com",
                        PasswordHash= "Qwerty!",
                        IsAdmin = false
                    },
                    new User()
                    {
                        Id= 3,
                        UserName ="Maksym Banatskyi",
                        Email = "Maksym@gmail.com",
                        PasswordHash= "Qwerty!",
                        IsAdmin = false
                    },
                    new User()
                    {
                        Id= 4,
                        UserName ="Maksym Lazarchuk",
                        Email = "MaksymL@gmail.com",
                        PasswordHash= "Qwerty!",
                        IsAdmin = false
                    },
                    new User()
                    {
                        Id= 5,
                        UserName ="Volodymyr Yakovchuk",
                        Email = "Volodymyr@gmail.com",
                        PasswordHash= "Qwerty!",
                        IsAdmin = false
                    },
                    new User()
                    {
                        Id= 6,
                        UserName ="Admin",
                        Email = "admin@gmail.com",
                        PasswordHash= "psw!admin",
                        IsAdmin = true
                    },
                }
            );
        }
        public static void SeedTicket(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket[]
                {
                    new Ticket()
                    {
                        Id = 1,
                        Price = 250,
                        HallId = 1,
                    },
                    new Ticket()
                    {
                        Id = 2,
                        Price = 220,
                        HallId = 3,
                    },
                    new Ticket()
                    {
                        Id = 3,
                        Price = 230,
                        HallId = 2,
                    },
                });
        }
    }

}
