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
        public string ReleaseDate { get; set; }
        public int? Runtime { get; set; }
        public List<TmdbCountry> ProductionCountries { get; set; }
        public List<TmdbGenre> Genres { get; set; }
        public TmdbCredits Credits { get; set; }
        public double VoteAverage { get; set; }
        public TmdbVideos Videos { get; set; }
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
    }

    public class TmdbCountry
    {
        public string Name { get; set; }
    }

    public class TmdbGenre
    {
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
        public List<TmdbVideo> Results { get; set; }
    }

    public class TmdbVideo
    {
        public string Key { get; set; }
        public string Type { get; set; }
    }
}