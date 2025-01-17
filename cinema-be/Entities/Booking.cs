namespace cinema_be.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime bookingTime { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public User User { get; set; }
        public Session Session { get; set; }
    }
}
