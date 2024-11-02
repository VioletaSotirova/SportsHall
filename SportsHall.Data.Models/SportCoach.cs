using System.ComponentModel.DataAnnotations.Schema;

namespace SportsHall.Data.Models
{
    public class SportCoach
    {
        public int CoachId { get; set; }
        public Coach Coach { get; set; } = null!;
        public int SportId { get; set; }
        public Sport Sport { get; set; } = null!;

    }
}
