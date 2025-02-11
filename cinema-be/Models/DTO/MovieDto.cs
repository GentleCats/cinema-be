namespace cinema_be.Models.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }
        public int TmdbId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public decimal Rating { get; set; }
        public string TrailerUrl { get; set; }
        public string ImageUrl { get; set; }
        public List<SessionDto> Sessions { get; set; } = new();
    }
}
