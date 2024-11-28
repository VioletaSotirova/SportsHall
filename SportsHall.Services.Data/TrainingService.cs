using Microsoft.EntityFrameworkCore;
using SportsHall.Data.Models;
using SportsHall.Data.Repository.Interfaces;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Web.ViewModels;
using System.Security.Cryptography.X509Certificates;


namespace SportsHall.Services.Data
{
    public class TrainingService : ITrainingService
    {
        private IRepository<Training, int> trainingRepository;
        private readonly ISportService sportService;
        private readonly ICoachService coachService;
        private readonly ITrainingStatusService trainingStatusService;

        public TrainingService(IRepository<Training, int> trainingRepository,
            ISportService sportService, ICoachService coachService,
            ITrainingStatusService trainingStatusService)
        {
            this.trainingRepository = trainingRepository;
            this.sportService = sportService;
            this.coachService = coachService;
            this.trainingStatusService = trainingStatusService;
        }
        public async Task<IEnumerable<TrainingsViewModel>> GetAllAsync()
        {
            var trainings = await GetAllTrainingsAsync();

            var model = trainings.Select(t => new TrainingsViewModel
            {
                Id = t.Id,
                SportName = t.Sport.Name,
                CoachName = $"{t.Coach.FirstName} {t.Coach.LastName}",
                TrainingStatus = t.TrainingStatus.Name,
                Start = t.Start,
                Location = t.Location,
                Duration = t.Duration,
                AvailableSpot = t.Sport.MaxParticipants
            });
 
            return model;
        }

        public async Task<TrainingCreateViewModel> GetCreateTrainingViewModel()
        {
            var model = new TrainingCreateViewModel
            {
                Sports = await sportService.GetSportsAsSelectItemAsync(),
                Coaches = await coachService.GetCoachesAsSelectItemAsync(),
                TrainingStatuses = await trainingStatusService.GetTrainingStatusesAsSelectItemAsync()
            };
            return model;
        }

        public async Task<Training> CreateAsync(TrainingCreateViewModel model)
        {
            Training training = new Training
            {
                SportId = model.SportId,
                CoachId = model.CoachId,
                Start = model.Start,
                Location = model.Location,
                Duration = model.Duration,
                AvailableSpot = model.AvailableSpot,
                TrainingStatusId = model.TrainingStatusId
            };

            await trainingRepository.AddAsync(training);

            return training;
        }

        public async Task<Training> GetByIdIncludeAsync(int id)
        {
            var training = await this.trainingRepository
                .GetAllAttached()
                .Include(t => t.Sport)
                .Include(t => t.Coach)
                .Include(t => t.TrainingStatus)
                .FirstOrDefaultAsync(s => s.Id == id);

            return training;
        }

        public async Task<List<Training>> GetAllTrainingsAsync()
        {
            var trainings = await this.trainingRepository
                .GetAllAttached()
                .Include(t => t.Sport)
                .Include(t => t.Coach)
                .Include(t => t.TrainingStatus)
                .ToListAsync();

            return trainings;
        }
    }
}
