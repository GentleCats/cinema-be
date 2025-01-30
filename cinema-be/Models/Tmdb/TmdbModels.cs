using System.Text.Json.Serialization;

namespace cinema_be.Models.Tmdb
{
    public class TmdbResponse
    {
        public List<TmdbMovie> Results { get; set; }
    }

    public class TmdbMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
        public int? Runtime { get; set; }
        [JsonPropertyName("production_countries")]
        public List<TmdbCountry> ProductionCountries { get; set; }
        public List<TmdbGenre> Genres { get; set; }
        public TmdbCredits Credits { get; set; }
        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }
        public TmdbVideos Videos { get; set; }
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
    }

    public class TmdbCountry
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class TmdbGenre
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class TmdbCredits
    {
        public List<TmdbCrew> Crew { get; set; }
        public List<TmdbCast> Cast { get; set; }
    }

    public class TmdbCrew
    {
        public string Job { get; set; }
        public string Name { get; set; }
    }

    public class TmdbCast
    {
        public string Name { get; set; }
    }

    public class TmdbVideos
    {
        [JsonPropertyName("results")]
        public List<TmdbVideo> Results { get; set; }
    }

    public class TmdbVideo
    {
        public string Key { get; set; }
        public string Type { get; set; }
    }
}