namespace cinema_be.Models.DTO
{
    public class SessionDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }  
        public int HallId { get; set; }  
        public decimal Price { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Date { get; set; }
    }

}
