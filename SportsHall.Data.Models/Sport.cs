using System.ComponentModel.DataAnnotations;

namespace SportsHall.Data.Models
{
    public class Sport
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int MaxParticipants { get; set; }
        public IEnumerable<SportCoach> SportsCoaches { get; set; } = new List<SportCoach>();
    }
}
