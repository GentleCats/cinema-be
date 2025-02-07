
using System.ComponentModel.DataAnnotations;

namespace cinema_be.Entities
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
        public int Capacity { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
