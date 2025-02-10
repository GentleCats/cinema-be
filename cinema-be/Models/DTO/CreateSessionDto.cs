namespace cinema_be.Models.DTOs
{
    public class CreateSessionDto
    {
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
