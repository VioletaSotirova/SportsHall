using AutoMapper;
using SportsHall.Data.Models;
using SportsHall.Services.Mapping;

namespace SportsHall.Web.ViewModels
{
    public class TrainingsViewModel : IMapFrom<Training>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string SportName { get; set; }
        public string CoachName { get; set; }
        public string TrainingStatus { get; set; }
        public DateTime Start { get; set; }
        public string Location { get; set; } = null!;
        public int Duration { get; set; }
        public int AvailableSpot { get; set; }
        public bool IsCurrentUserSigned { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Training, TrainingsViewModel>()
            .ForMember(
                dest => dest.SportName,
                opt => opt.MapFrom(src => src.Sport.Name))
            .ForMember(
                dest => dest.CoachName,
                opt => opt.MapFrom(src => $"{src.Coach.FirstName} {src.Coach.LastName}"))
            .ForMember(
                dest => dest.TrainingStatus,
                opt => opt.MapFrom(src => src.TrainingStatus.Name))
            .ForMember(
                dest => dest.IsCurrentUserSigned,
                opt => opt.Ignore()); 
        }
    }
}
