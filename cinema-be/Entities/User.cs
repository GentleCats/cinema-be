
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace cinema_be.Entities
{
    public class User: IdentityUser<int>
    {
        public ICollection<Ticket> Tickets { get; set; }
    }
}
