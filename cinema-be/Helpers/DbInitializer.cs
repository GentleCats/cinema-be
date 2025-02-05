using cinema_be.Entities;
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
                        MovieId = 85,
                        HallId = 1,
                        StartTime = new TimeSpan(19, 55, 0),
                        EndTime = new TimeSpan(21, 45, 0),
                        Date = new DateTime(2025, 1, 18),  
                    },
                    new Session()
                    {
                        Id = 2,
                        MovieId = 85,
                        HallId = 1,
                        StartTime = new TimeSpan(19, 55, 0),
                        EndTime = new TimeSpan(21, 45, 0),
                        Date = new DateTime(2025, 1, 19),  
                    },
                    new Session()
                    {
                        Id = 3,
                        MovieId = 85,
                        HallId = 1,
                        StartTime = new TimeSpan(19, 55, 0),
                        EndTime = new TimeSpan(21, 45, 0),
                        Date = new DateTime(2025, 1, 20),  
                    },
                    new Session()
                    {
                        Id = 4,
                        MovieId = 426063,
                        HallId = 2,
                        StartTime = new TimeSpan(10, 10, 0),
                        EndTime = new TimeSpan(12, 00, 0),
                        Date = new DateTime(2025, 1, 18),  
                    },
                    new Session()
                    {
                        Id = 5,
                        MovieId = 426063,
                        HallId = 2,
                        StartTime = new TimeSpan(16, 20, 0),
                        EndTime = new TimeSpan(18, 10, 0),
                        Date = new DateTime(2025, 1, 18),  
                    },
                    new Session()
                    {
                        Id = 6,
                        MovieId = 426063,
                        HallId = 2,
                        StartTime = new TimeSpan(10, 10, 0),
                        EndTime = new TimeSpan(12, 00, 0),
                        Date = new DateTime(2025, 1, 19),  
                    },
                    new Session()
                    {
                        Id = 7,
                        MovieId = 426063,
                        HallId = 2,
                        StartTime = new TimeSpan(16, 20, 0),
                        EndTime = new TimeSpan(18, 10, 0),
                        Date = new DateTime(2025, 1, 19),  
                    },
                    new Session()
                    {
                        Id = 8,
                        MovieId = 426063,
                        HallId = 3,
                        StartTime = new TimeSpan(20, 10, 0),
                        EndTime = new TimeSpan(22, 10, 0),
                        Date = new DateTime(2025, 1, 18),  
                    },
                    new Session()
                    {
                        Id = 9,
                        MovieId = 426063,
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
                        Capacity = 302,
                        Rows = 14,
                        Cols = 22
                    },
                    new Hall(){
                        Id = 2,
                        Name="Парадиз",
                        Capacity = 377,
                        Rows = 18,
                        Cols = 21
                    },
                    new Hall(){
                        Id = 3,
                        Name="Арена",
                        Capacity = 346,
                        Rows = 15,
                        Cols = 23
                       
                    },
                });
        }

        
        //public static void SeedUser(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //        new User[]
        //        {
        //            new User()
        //            {
        //                Id= 1,
        //                UserName ="Sasha Osadets",
        //                Email = "osadets@gmail.com",
        //            },
        //            new User()
        //            {
        //                Id= 2,
        //                UserName ="Fedor",
        //                Email = "fedor@gmail.com",
        //            },
        //            new User()
        //            {
        //                Id= 3,
        //                UserName ="Maksym Banatskyi",
        //                Email = "Maksym@gmail.com",
        //            },
        //            new User()
        //            {
        //                Id= 4,
        //                UserName ="Maksym Lazarchuk",
        //                Email = "MaksymL@gmail.com",
        //            },
        //            new User()
        //            {
        //                Id= 5,
        //                UserName ="Volodymyr Yakovchuk",
        //                Email = "Volodymyr@gmail.com",
        //            },
        //            new User()
        //            {
        //                Id= 6,
        //                UserName ="Admin",
        //                Email = "admin@gmail.com",
        //            },
        //        }
        //    );
        //}

        //public static void SeedTicket(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Ticket>().HasData(
        //        new Ticket[]
        //        {
        //            new Ticket()
        //            {
        //                Id = 1,
        //                Price = 250,
        //            },
        //            new Ticket()
        //            {
        //                Id = 2,
        //                Price = 220,
        //            },
        //            new Ticket()
        //            {
        //                Id = 3,
        //                Price = 230,
        //                HallId = 2,
        //            },
        //        });
        //}
    
    }
}
