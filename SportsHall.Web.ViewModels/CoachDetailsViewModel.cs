using SportsHall.Data.Models;
using SportsHall.Services.Mapping;

namespace SportsHall.Web.ViewModels
{
    public class CoachDetailsViewModel : IMapFrom<Coach>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string Phone { get; set; } = null!;
        public string Expirience { get; set; } = null!;
        public string? ImageUrl { get; set; }
 
    }
}
