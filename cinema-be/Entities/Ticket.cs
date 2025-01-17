namespace cinema_be.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
