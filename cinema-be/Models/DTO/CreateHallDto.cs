using System.ComponentModel.DataAnnotations;

namespace cinema_be.Models.DTOs
{
    public class CreateHallDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
        public int Capacity { get; set; }
    }
}
