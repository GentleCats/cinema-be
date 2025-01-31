
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema_be.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
        [Required]
        public DateTime BookingTime { get; set; }
        [Required, ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [Required, ForeignKey(nameof(Session))]
        public int SessionId { get; set; }
        public User User { get; set; }
        public Session Session { get; set; }
    }
}
