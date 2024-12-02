using SportsHall.Data.Models;
using SportsHall.Services.Mapping;

namespace SportsHall.Web.ViewModels
{
    public class TrainingsViewModel
    {
        public int Id { get; set; }
        public string SportName { get; set; }
        public string CoachName { get; set; }
        public string TrainingStatus { get; set; }
        public DateTime Start { get; set; }
        public string Location { get; set; } = null!;
        public int Duration { get; set; }
        public int AvailableSpot { get; set; }
        public bool IsUserSigned { get; set; }
    }
}
