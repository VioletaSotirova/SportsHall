using System.ComponentModel.DataAnnotations;

using SportsHall.Data.Models;
using static SportsHall.Common.EntityValidationConstants.Coach;
using static SportsHall.Common.EntityValidationMessages.Coach;
using SportsHall.Services.Mapping;


namespace SportsHall.Web.ViewModels
{
    public class CoachEditViewModel : IMapFrom<Coach>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = FirstNameRequiredMessage)]
        [MaxLength(FirstNameMaxLength, ErrorMessage = FirstNameMaxLengthMessage)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = LastNameRequiredMessage)]
        [MaxLength(LastNameMaxLength, ErrorMessage = LastNameMaxLengthMessage)]
        public string LastName { get; set; } = null!;

        [RegularExpression(EmailValidation, ErrorMessage = InvalidEmailMessage)]
        public string? Email { get; set; }

        [Required(ErrorMessage = PhoneRequiredMessage)]
        [MaxLength(PhoneMaxLength)]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = ExpirienceRequiredMessage)]
        [MaxLength(ExpirienceMaxLength, ErrorMessage = ExpirienceMaxLengthMessage)]
        public string Expirience { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
