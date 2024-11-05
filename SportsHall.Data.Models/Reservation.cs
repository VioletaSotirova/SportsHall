
using Microsoft.AspNetCore.Identity;

namespace SportsHall.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; } = null!;
        public int UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
    }
}
