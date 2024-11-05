using Microsoft.AspNetCore.Identity;

namespace SportsHall.Data.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public IEnumerable<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
