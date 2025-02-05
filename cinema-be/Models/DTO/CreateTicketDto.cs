namespace cinema_be.Models.DTOs
{
    public class CreateTicketDto
    {
        public int HallId { get; set; }  
        public int SeatNumber { get; set; }  
        public decimal Price { get; set; }
    }
}
