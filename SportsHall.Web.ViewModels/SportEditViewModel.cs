using AutoMapper;
using SportsHall.Data.Models;
using SportsHall.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace SportsHall.Web.ViewModels
{
    public class SportEditViewModel : IMapFrom<Sport>
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

        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Sport, SportEditViewModel>();
        }

    }
}
