
using System.ComponentModel.DataAnnotations;

namespace cinema_be.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
