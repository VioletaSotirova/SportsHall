using SportsHall.Web.ViewModels;
using SportsHall.Data.Models;

namespace SportsHall.Services.Data.Interfaces
{
    public interface ISportService
    {
        Task<IEnumerable<SportsViewModel>> GetAllAsync();
        Task<SportDetailsViewModel> DetailsAsync(int id);
        Task<SportEditViewModel> EditAsync(int id);
        Task UpdateSportAsync(SportEditViewModel model);
        Task<Sport> GetByIdWithCoachesAsync(int id);
        Task<Sport> GetByIdAsync(int id);

    }
}