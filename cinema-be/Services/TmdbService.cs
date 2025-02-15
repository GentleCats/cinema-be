
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using cinema_be.Entities;
using cinema_be.Models.Tmdb;
using cinema_be.Configuration;
using cinema_be.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using cinema_be;
//1222064
public class TmdbService: ITMDBService
{
    private readonly HttpClient _httpClient;
    //private readonly AppDbContext _dbContext;
    private readonly string _apiKey;
    private readonly JsonSerializerOptions _jsonOptions;

    public TmdbService(HttpClient httpClient, IOptions<TmdbSettings> settings)
    {
        _httpClient = httpClient;
        _apiKey = settings.Value.ApiKey;
        _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
       // _dbContext = dbContext;
    }

    public async Task<List<Movie>> GetPopularMoviesAsync(int page = 1)
    {
        var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/popular?api_key={_apiKey}&page={page}");
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error fetching popular movies: {response.ReasonPhrase}");
        }

        var content = await response.Content.ReadAsStringAsync();
        var tmdbResponse = JsonSerializer.Deserialize<TmdbResponse>(content, _jsonOptions);

        var tasks = tmdbResponse.Results.Select(tmdbMovie => GetMovieDetailsAsync(tmdbMovie.Id));

        //foreach (var tmdbMovie in tmdbResponse.Results)
        //{
        //    tasks.Add(GetMovieDetailsAsync(tmdbMovie.Id));
        //}

        var movies = await Task.WhenAll(tasks);
        var validMovies = movies.Where(m => m != null).ToList();

        //foreach (var movie in validMovies)
        //{
        //    var existingMovie = await _dbContext.Movies
        //        .FirstOrDefaultAsync(m => m.Title == movie.Title);

        //    if (existingMovie == null)
        //    {
        //        _dbContext.Movies.Add(movie);
        //    }
        //}

        //await _dbContext.SaveChangesAsync();

        return validMovies;
    }

    public async Task<Movie> GetMovieDetailsAsync(int movieId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/{movieId}?api_key={_apiKey}&append_to_response=credits,videos");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var detailedMovie = JsonSerializer.Deserialize<TmdbMovie>(content, _jsonOptions);

            DateTime? releaseDate = null;
            if (!string.IsNullOrEmpty(detailedMovie.ReleaseDate) && DateTime.TryParse(detailedMovie.ReleaseDate, out var parsedDate))
            {
                releaseDate = parsedDate;
            }
            //Console.WriteLine(detailedMovie.ProductionCountries);
            return new Movie
            {
                Id = detailedMovie.Id,
                Title = detailedMovie.Title,
                Description = detailedMovie.Overview,
                Duration = detailedMovie.Runtime.HasValue ? TimeSpan.FromMinutes(detailedMovie.Runtime.Value) : TimeSpan.FromMinutes(120),
                Country = detailedMovie.ProductionCountries?.FirstOrDefault()?.Name ?? "Unknown",
                Genre = detailedMovie.Genres != null ? string.Join(", ", detailedMovie.Genres.Select(g => g.Name)) : "Unknown",
                ReleaseDate = releaseDate ?? DateTime.MinValue,
                EndDate = releaseDate.HasValue ? releaseDate.Value.AddMonths(6) : (DateTime?)null,
                Director = detailedMovie.Credits?.Crew?.FirstOrDefault(c => c.Job == "Director")?.Name ?? "Unknown",
                Cast = detailedMovie.Credits?.Cast?.Take(5).Select(c => new Actor
                {
                    Id = c.Id,
                    Name = c.Name,
                    Character = c.Character,
                    PhotoUrl = $"https://image.tmdb.org/t/p/w500{c.PhotoUrl}"
                }).ToList(),
                Rating = detailedMovie.VoteAverage != 0 ? (decimal)detailedMovie.VoteAverage : 0,
                TrailerUrl = detailedMovie.Videos?.Results?.FirstOrDefault(v => v.Type == "Trailer") != null
                    ? $"https://www.youtube.com/watch?v={detailedMovie.Videos.Results.First(v => v.Type == "Trailer").Key}"
                    : null,
                ImageUrl = detailedMovie.PosterPath != null
                    ? $"https://image.tmdb.org/t/p/w500{detailedMovie.PosterPath}"
                    : "https://upload.wikimedia.org/wikipedia/commons/a/a3/Image-not-found.png?20210521171500"
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching details for movie ID {movieId}: {ex.Message}");
            return null;
        }
    }

}
