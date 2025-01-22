using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema_be.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime BookingTime { get; set; }
        [Required, ForeignKey("User")]
        public int UserId { get; set; }
        [Required, ForeignKey("Session")]
        public int SessionId { get; set; }
        public User User { get; set; }
        public Session Session { get; set; }
    }
}