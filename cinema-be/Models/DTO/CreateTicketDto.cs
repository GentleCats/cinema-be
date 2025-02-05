namespace cinema_be.Models.DTOs
{
    public class CreateTicketDto
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }
    }
}
