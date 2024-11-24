using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsHall.Data.Models;

namespace SportsHall.Web.ViewModels
{
    public class SportEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Max participants must be greater than 0.")]
        public int MaxParticipants { get; set; }

        public string? ImageUrl { get; set; }

        public IList<SelectListItem>? AvailableCoaches { get; set; } 

        public List<int> SelectedCoaches { get; set; } = new List<int>();

        public List<string> SelectedCoachesNames { get; set; } = new List<string>();
    }
}
