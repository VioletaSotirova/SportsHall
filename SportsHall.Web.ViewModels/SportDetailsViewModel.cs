using SportsHall.Data.Models;
using SportsHall.Services.Mapping;

namespace SportsHall.Web.ViewModels
{
    public class SportDetailsViewModel : IMapFrom<Sport>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

    }
}
