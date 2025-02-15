
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cinema_be.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TmdbId { get; set; }

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


        [Range(0, 10)]
        public decimal Rating { get; set; }

        public string? TrailerUrl { get; set; }

        public string? ImageUrl { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public List<Actor> Cast { get; set; }

    }

}
