using Microsoft.AspNetCore.Mvc.Rendering;
using SportsHall.Web.ViewModels;
using SportsHall.Data.Models;

namespace SportsHall.Services.Data.Interfaces
{
    public interface ICoachService
    {
        Task<IEnumerable<CoachesViewModel>> GetAllAsync();
        Task<CoachDetailsViewModel> DetailsAsync(int id);
        Task<List<SelectListItem>> GetAllCoachesAsSelectListAsync();
        Task<List<string>> GetCoachNamesByIdsAsync(List<int> coachIds);
        Task<Coach> GetByIdWithSportsAsync(int id);
        Task<Coach> GetCoachByIdAsync(int id);
    }
}
