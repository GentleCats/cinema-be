namespace cinema_be.Models.DTOs
{
    public class CreateTicketDto
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public int Seat { get; set; }
        public int Cols { get; set; }
        public int Rows { get; set; }
    }
}
