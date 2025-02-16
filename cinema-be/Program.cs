using cinema_be.Configuration;
using cinema_be.Entities;
using cinema_be.Helpers;
using cinema_be.Interfaces;
using cinema_be.Services;
using cinema_be.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace cinema_be
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.Configure<TmdbSettings>(builder.Configuration.GetSection("TmdbSettings"));

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultDB"));
            });

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddValidatorsFromAssemblyContaining<CreateHallDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateSessionDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateTicketDtoValidator>();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    return new BadRequestObjectResult(new { success = false, errors });
                };
            });

            builder.Services.AddControllers();


            builder.Services.AddHttpClient<TmdbService>();


            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<ITMDBService, TmdbService>();
            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddScoped<IHallService, HallService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MappingProfile));


            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("TokenKey");

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JWT Secret Key is missing or empty in appsettings.json.");
            }

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        };
    });

            builder.Services.AddAuthorization();



            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
                });
            });


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    var tmdbService = services.GetRequiredService<TmdbService>();
                    await DbInitializer.SeedMovie(context, tmdbService);
                    // await tmdbService.FixMoviePostersAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred during data seeding: {ex.Message}");
                }
            }


            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Enable CORS
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

                try
                {
                    await SeederDB.SeedData(serviceProvider);
                    logger.LogInformation("Seeding data to the db");

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "A problem occurred during migration");
                }
            }

            app.Run();
        }
    }

}
