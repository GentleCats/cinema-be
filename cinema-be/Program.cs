
using cinema_be.Configuration;
using cinema_be.Helpers;
using Microsoft.EntityFrameworkCore;

namespace cinema_be
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.Configure<TmdbSettings>(builder.Configuration.GetSection("TmdbSettings"));
            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultDB"));
            });

            builder.Services.AddControllers();
            builder.Services.AddHttpClient<TmdbService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    var tmdbService = services.GetRequiredService<TmdbService>();

                    // Виклик асинхронного методу SeedMovie
                    await DbInitializer.SeedMovie(context, tmdbService);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred during data seeding: {ex.Message}");
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }

}
