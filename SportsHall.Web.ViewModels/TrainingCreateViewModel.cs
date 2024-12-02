using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SportsHall.Web.ViewModels
{
    public class TrainingCreateViewModel
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue)]
        public int SportId { get; set; }
        public ICollection<SelectListItem> Sports { get; set; } = new List<SelectListItem>();
        [Range(1, int.MaxValue)]
        public int CoachId { get; set; }
        public ICollection<SelectListItem> Coaches { get; set; } = new List<SelectListItem>();
        [Range(1, int.MaxValue)]
        public int TrainingStatusId { get; set; }
        public ICollection<SelectListItem> TrainingStatuses { get; set; } = new List<SelectListItem>();
        public DateTime Start { get; set; }
        public string Location { get; set; } = string.Empty;
        public int Duration { get; set; }
    }
}

