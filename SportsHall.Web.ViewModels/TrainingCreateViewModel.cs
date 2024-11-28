using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsHall.Web.ViewModels
{
    public class TrainingCreateViewModel
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public IEnumerable<SelectListItem> Sports { get; set; } = new List<SelectListItem>();
        public int CoachId { get; set; }
        public IEnumerable<SelectListItem> Coaches { get; set; } = new List<SelectListItem>();
        public int TrainingStatusId { get; set; }
        public IEnumerable<SelectListItem> TrainingStatuses { get; set; } = new List<SelectListItem>();
        public DateTime Start { get; set; }
        public string Location { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int AvailableSpot { get; set; }
    }
}

