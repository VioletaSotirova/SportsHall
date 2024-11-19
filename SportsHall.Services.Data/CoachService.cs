using Microsoft.EntityFrameworkCore;

using SportsHall.Data.Models;
using SportsHall.Data.Repository.Interfaces;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Web.ViewModels;
using SportsHall.Services.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;




namespace SportsHall.Services.Data
{
    public class CoachService : ICoachService
    {
        private IRepository<Coach, int> coachRepository;

        public CoachService(IRepository<Coach, int> coachRepository)
        {
            this.coachRepository = coachRepository;
        }

        public async Task<CoachDetailsViewModel> DetailsAsync(int id)
        {
            var coach = await this.coachRepository
                 .GetAllAttached()
                 .Where(s => s.Id == id)
                 .To<CoachDetailsViewModel>()
                 .FirstOrDefaultAsync();

            return coach;
        }

        public async Task<IEnumerable<CoachesViewModel>> GetAllAsync()
        {
            var coaches = await this.coachRepository
                .GetAllAttached()
                .To<CoachesViewModel>()
                .ToListAsync();

            return coaches;
        }

        public async Task<List<SelectListItem>> GetAllCoachesAsSelectListAsync()
        {
            var coaches = await this.coachRepository
                .GetAllAttached()
                .Select(c => new SelectListItem
                {
                    Text = $"{c.FirstName} {c.LastName}",
                    Value = c.Id.ToString()
                })
                .ToListAsync();

            return coaches;
        }

        public async Task<List<string>> GetCoachNamesByIdsAsync(List<int> coachIds)
        {
            return await this.coachRepository
                .GetAllAttached() 
                .Where(c => coachIds.Contains(c.Id))
                .Select(c => $"{c.FirstName} {c.LastName}")
                .ToListAsync();
        }

        public async Task<Coach> GetByIdWithSportsAsync(int id)
        {
            var coach = await this.coachRepository
                .GetAllAttached()
                .Include(c => c.SportsCoaches)
                .ThenInclude(sc => sc.Sport)
                .FirstOrDefaultAsync();
            return coach;
        }

        public async Task<Coach> GetCoachByIdAsync(int id)
        {
           var coach = await this.coachRepository.GetByIdAsync(id);

            return coach;
        }
    }
}