using AutoMapper;
using SportsHall.Data.Models;
using SportsHall.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using static SportsHall.Common.EntityValidationConstants.Sport;
using static SportsHall.Common.EntityValidationMessages.Sport;



namespace SportsHall.Web.ViewModels
{
    public class SportEditViewModel : IMapFrom<Sport>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = NameRequiredMessage)]
        [MinLength(NameMinLength, ErrorMessage = NameMinLengthMessage)]
        [MaxLength(NameMaxLength, ErrorMessage = NameMaxLengthMessage)]      
        public string Name { get; set; }

        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [MinLength(DescriptionMinLength, ErrorMessage = DescriptionMinLengthMessage)]
        [MaxLength(DescriptionMaxLength, ErrorMessage = DescriptionMaxLengthMessage)]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = MaxParticipantsMessage)]
        public int MaxParticipants { get; set; }
        public string? ImageUrl { get; set; }
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Sport, SportEditViewModel>();
        }
    }
}
