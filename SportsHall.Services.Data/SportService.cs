using Microsoft.EntityFrameworkCore;

using SportsHall.Data.Repository.Interfaces;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Web.ViewModels;
using SportsHall.Data.Models;
using SportsHall.Services.Mapping;

namespace SportsHall.Services.Data
{
    public class SportService : ISportService
    {
        private IRepository<Sport, int> sportRepository;
        public SportService(IRepository<Sport, int> sportRepository)
        {
            this.sportRepository = sportRepository;
        }
        public async Task<IEnumerable<SportsViewModel>> GetAllAsync()
        {
            var sports = await this.sportRepository
                .GetAllAttached()
                .To<SportsViewModel>()
                .ToListAsync();

            return sports;
        }
    }
}
