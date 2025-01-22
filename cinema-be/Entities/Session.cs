
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema_be.Entities
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        [ForeignKey("Hall")]
        public int HallId { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }

}
