using System.ComponentModel.DataAnnotations;

namespace cinema_be.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        [Required, MaxLength(50)]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [MaxLength(100)]
        public string? Director { get; set; } 

        [MaxLength(300)]
        public string? Cast { get; set; } 

        [Range(0, 10)]
        public decimal Rating { get; set; }

        public string? TrailerUrl { get; set; } 

        public string? ImageUrl { get; set; } 

        public ICollection<Session> Sessions { get; set; }
    }

}
