using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static SportsHall.Common.EntityValidationConstants.Training;
using static SportsHall.Common.EntityValidationMessages.Training;

namespace SportsHall.Web.ViewModels
{
    public class TrainingCreateViewModel
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = ChooseMessage)]
        public int SportId { get; set; }
        public ICollection<SelectListItem> Sports { get; set; } = new List<SelectListItem>();
        [Range(1, int.MaxValue, ErrorMessage = ChooseMessage)]
        public int CoachId { get; set; }
        public ICollection<SelectListItem> Coaches { get; set; } = new List<SelectListItem>();
        [Range(1, int.MaxValue, ErrorMessage = ChooseMessage)]
        public int TrainingStatusId { get; set; }
        public ICollection<SelectListItem> TrainingStatuses { get; set; } = new List<SelectListItem>();
        public DateTime Start { get; set; }

        [Required(ErrorMessage = LocationRequiredMessage)]
        [MaxLength(LocationMaxLength, ErrorMessage = LocationMaxLengthMessage)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = DurationRequiredMessage)]
        [Range(20, int.MaxValue, ErrorMessage = DurationMinLengthMessage)]
        public int Duration { get; set; }
    }
}

