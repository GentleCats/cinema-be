namespace cinema_be.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int HallIdId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime date { get; set; }
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }

    }
}
