using Microsoft.AspNetCore.Mvc.Rendering;
using SportsHall.Web.ViewModels;
using SportsHall.Data.Models;

namespace SportsHall.Services.Data.Interfaces
{
    public interface ICoachService
    {
        Task<IEnumerable<CoachesViewModel>> GetAllAsync();
        Task<CoachDetailsViewModel> DetailsAsync(int id);
        Task<CoachEditViewModel> EditAsync(int id);
        Task<Coach> GetCoachByIdAsync(int id);
        Task UpdateCoachAsync(CoachEditViewModel model);
        Task<Coach> CreateAsync(CoachEditViewModel model);
        Task DeleteAsync(int id);
        Task<IEnumerable<SelectListItem>> GetCoachesAsSelectItemAsync();
    }
}
