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
        public async Task<CoachEditViewModel> EditAsync(int id)
        {
            var coach = await GetCoachByIdAsync(id);

            var model = new CoachEditViewModel
            {
                Id = coach.Id,
                FirstName = coach.FirstName,
                LastName = coach.LastName,
                Phone = coach.Phone,
                Email = coach.Email,
                Expirience = coach.Expirience,
                ImageUrl = coach.ImageUrl,
            };

            return model;
        }

        public async Task UpdateCoachAsync(CoachEditViewModel model)
        {
            var coach = await GetCoachByIdAsync(model.Id);

            if (coach != null)
            {
                coach.FirstName = model.FirstName;
                coach.LastName = model.LastName;
                coach.Expirience = model.Expirience;
                coach.Phone = model.Phone;
                coach.Email = model.Email;
                coach.ImageUrl = model.ImageUrl;

                await this.coachRepository.UpdateAsync(coach);
            }
        }

        public async Task<Coach> CreateAsync(CoachEditViewModel model)
        {
            var coach = new Coach
            {
               FirstName = model.FirstName,
               LastName = model.LastName,
               Expirience = model.Expirience,
               Phone = model.Phone,
               Email = model.Email,
               ImageUrl = model.ImageUrl,
            };

            await coachRepository.AddAsync(coach);
            return coach;
        }

        public async Task DeleteAsync(int id)
        {
            var coach = await coachRepository.GetByIdAsync(id);

            if (coach != null)
            {

                await coachRepository.DeleteAsync(coach);

            }
        }
        public async Task<Coach> GetCoachByIdAsync(int id)
        {
           var coach = await this.coachRepository.GetByIdAsync(id);

            return coach;
        }

        public async Task<IEnumerable<SelectListItem>> GetCoachesAsSelectItemAsync()
        {
            return (await coachRepository.GetAllAsync())
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = $"{c.FirstName} {c.LastName}" });
        }
    }
}