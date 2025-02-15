using System.ComponentModel.DataAnnotations;
using cinema_be.Entities;

public class Actor
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Character { get; set; }
    public string PhotoUrl { get; set; }
}
