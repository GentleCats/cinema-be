namespace cinema_be.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string title {  get; set; }
        public string description { get; set; }
        public string duration { get; set; }
        public string genre { get; set; }
        public string type { get; set; }
        public DateTime releaseDate { get; set; }
        public DateTime endDate { get; set; }
        public string director { get; set; }
        public string casr { get; set; }
        public decimal rating { get; set; }
        public string trailerUrl { get; set; }
        public string imageUrl { get; set; }




    }
}
