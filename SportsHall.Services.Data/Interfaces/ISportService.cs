using SportsHall.Web.ViewModels;

namespace SportsHall.Services.Data.Interfaces
{
    public interface ISportService
    {
        Task<IEnumerable<SportsViewModel>> GetAllAsync();
        Task<SportDetailsViewModel> DetailsAsync(int id);
    }
}