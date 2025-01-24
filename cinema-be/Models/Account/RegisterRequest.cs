using System.ComponentModel.DataAnnotations;

namespace cinema_be.Models.Account
{
    public class RegisterRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
