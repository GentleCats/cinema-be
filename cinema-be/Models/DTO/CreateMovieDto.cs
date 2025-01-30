namespace cinema_be.Models.DTOs
{
    public class CreateMovieDto
    {
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
    }
}
