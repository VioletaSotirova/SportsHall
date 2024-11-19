using Microsoft.EntityFrameworkCore;

using SportsHall.Data.Repository.Interfaces;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Data.Models;
using SportsHall.Services.Mapping;
using SportsHall.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SportsHall.Services.Data
{
    public class SportService : ISportService
    {
        private IRepository<Sport, int> sportRepository;
        private readonly ICoachService coachService;

        public SportService(IRepository<Sport, int> sportRepository, ICoachService coachService)
        {
            this.sportRepository = sportRepository;
            this.coachService = coachService;
        }
        public async Task<IEnumerable<SportsViewModel>> GetAllAsync()
        {
            var sports = await this.sportRepository
                .GetAllAttached()
                .To<SportsViewModel>()
                .ToListAsync();

            return sports;
        }

        public async Task<SportDetailsViewModel> DetailsAsync(int id)
        {
            var sport = await this.sportRepository
                 .GetAllAttached()
                 .Where(s => s.Id == id)
                 .To<SportDetailsViewModel>()
                 .FirstOrDefaultAsync();

            return sport;
        }
        public async Task<SportEditViewModel> EditAsync(int id)
        {
            var sport = await GetByIdWithCoachesAsync(id);

            var model = new SportEditViewModel
            {
                Id = sport.Id,
                Name = sport.Name,
                Description = sport.Description,
                MaxParticipants = sport.MaxParticipants,
                ImageUrl = sport.ImageUrl,
                SelectedCoaches = sport.SportsCoaches.Select(sc => sc.CoachId).ToList(),
                AvailableCoaches = await this.coachService.GetAllCoachesAsSelectListAsync(),
                SelectedCoachesNames = sport.SportsCoaches.Select(sc => $"{sc.Coach.FirstName} {sc.Coach.LastName}").ToList(),
            };

            return model;
        }
        public async Task UpdateSportAsync(SportEditViewModel model)
        {
            var sport = await GetByIdWithCoachesAsync(model.Id);
         
            if (sport != null)
            {              
                sport.Name = model.Name;
                sport.Description = model.Description;
                sport.MaxParticipants = model.MaxParticipants;
                sport.ImageUrl = model.ImageUrl;

                var currentCoachIds = sport.SportsCoaches.Select(sc => sc.CoachId).ToList();

                var coachIdsToRemove = currentCoachIds.Except(model.SelectedCoaches).ToList();
                var coachIdsToAdd = model.SelectedCoaches.Except(currentCoachIds).ToList();

                sport.SportsCoaches = sport.SportsCoaches
                    .Where(sc => !coachIdsToRemove.Contains(sc.CoachId))
                    .ToList();

                foreach (var coachId in coachIdsToAdd)
                {
                    sport.SportsCoaches.Add(new SportCoach
                    {
                        SportId = sport.Id,
                        CoachId = coachId,
                    });
                }

                await this.sportRepository.UpdateAsync(sport);
            }

            /*var sport = await GetByIdWithCoachesAsync(model.Id);

            if (sport != null)
            {
                sport.Name = model.Name;
                sport.Description = model.Description;
                sport.MaxParticipants = model.MaxParticipants;
                sport.ImageUrl = model.ImageUrl;

                coachService.GetByIdWithSportsAsync(model.Id);

                //sport.SportsCoaches.Clear();
                //foreach (var coachId in model.SelectedCoaches)
                //{
                //    sport.SportsCoaches.Add(new SportCoach
                //    {
                //        SportId = sport.Id,
                //        CoachId = coachId
                //    });
                //}
            }
            await sportRepository.UpdateAsync(sport);*/
        }

        public async Task<Sport> GetByIdWithCoachesAsync(int id)
        {
            var sport = await this.sportRepository
                .GetAllAttached()
                .Include(s => s.SportsCoaches)
                .ThenInclude(sc => sc.Coach)
                .FirstOrDefaultAsync(s => s.Id == id);

            return sport;
        }

        public async Task<Sport> GetByIdAsync(int id)
        {
            return await sportRepository.GetByIdAsync(id);
        }
    }
}
