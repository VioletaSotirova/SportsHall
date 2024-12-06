using SportsHall.Data.Models;
using SportsHall.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHall.Web.ViewModels
{
    public class CoachEditViewModel : IMapFrom<Coach>
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
