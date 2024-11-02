using System.ComponentModel.DataAnnotations;

namespace SportsHall.Web.ViewModels
{
    public class SportsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Image { get; set; }
    }
}
