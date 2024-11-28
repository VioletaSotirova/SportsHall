using SportsHall.Web.ViewModels;
using SportsHall.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsHall.Services.Data.Interfaces
{
    public interface ISportService
    {
        Task<IEnumerable<SportsViewModel>> GetAllAsync();
        Task<SportDetailsViewModel> DetailsAsync(int id);
        Task<SportEditViewModel> EditAsync(int id);
        Task UpdateSportAsync(SportEditViewModel model);
        Task<Sport> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<Sport> CreateAsync(SportEditViewModel model);
        Task<IEnumerable<SelectListItem>> GetSportsAsSelectItemAsync();
    }
}