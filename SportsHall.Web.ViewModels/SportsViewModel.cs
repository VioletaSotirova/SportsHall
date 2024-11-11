using System.ComponentModel.DataAnnotations;
using SportsHall.Services.Mapping;
using SportsHall.Data.Models;

namespace SportsHall.Web.ViewModels
{
    public class SportsViewModel : IMapFrom<Sport>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? ImageUrl { get; set; }
    }
}
