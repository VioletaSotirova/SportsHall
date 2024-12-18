﻿using Microsoft.EntityFrameworkCore;
using SportsHall.Data.Models;
using SportsHall.Data.Repository.Interfaces;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using SportsHall.Services.Mapping;


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
        public async Task<IEnumerable<TrainingsViewModel>> GetAllAsync(string userId)
        {
            var trainings = await GetAllTrainingsAsync();

            var models = trainings.Select(training =>
            {
                var model = AutoMapperConfig.MapperInstance.Map<TrainingsViewModel>(training);

                if (userId != null)
                {
                    model.IsCurrentUserSigned = training.Reservations.Any(r => r.UserId == int.Parse(userId));
                }
                else
                {
                    model.IsCurrentUserSigned = false; 
                }

                return model;
            }).ToList();

            return models;
        }
        public async Task<TrainingCreateViewModel> GetCreateTrainingViewModel()
        {
            var model = new TrainingCreateViewModel
            {
                Sports = await sportService.GetSportsAsSelectItemAsync(),
                Coaches = await coachService.GetCoachesAsSelectItemAsync(),
                TrainingStatuses = await trainingStatusService.GetTrainingStatusesAsSelectItemAsync(),
                Start = DateTime.Now
            };

            model.Sports.Add(new SelectListItem("--- Choose sport --- ", "0"));
            model.Coaches.Add(new SelectListItem("--- Choose coach ---", "0"));
            model.TrainingStatuses.Add(new SelectListItem("--- Choose training status ---", "0"));

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
                TrainingStatusId = model.TrainingStatusId,
                AvailableSpot = await sportService.GetSportMaxParticipantsAsync(model.SportId)
            };

            await trainingRepository.AddAsync(training);

            return training;
        }

        public async Task<TrainingCreateViewModel> EditAsync(int id)
        {
            var training = await trainingRepository.GetByIdAsync(id);

            var model = new TrainingCreateViewModel
            {
                Id = training.Id,
                SportId = training.SportId,
                CoachId = training.CoachId,
                Start = training.Start,
                Location = training.Location,
                Duration = training.Duration,
                TrainingStatusId = training.TrainingStatusId,
                Sports = await sportService.GetSportsAsSelectItemAsync(),
                Coaches = await coachService.GetCoachesAsSelectItemAsync(),
                TrainingStatuses = await trainingStatusService.GetTrainingStatusesAsSelectItemAsync()
            };

            return model;
        }

        public async Task UpdateAsync(TrainingCreateViewModel model)
        {
            var training = await trainingRepository.GetByIdAsync(model.Id);

            if (training != null)
            {
                training.Id = model.Id;
                training.SportId = model.SportId;
                training.CoachId = model.CoachId;
                training.Start = model.Start;
                training.Location = model.Location;
                training.Duration = model.Duration;
                training.TrainingStatusId = model.TrainingStatusId;

                await this.trainingRepository.UpdateAsync(training);
            }
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
                .Include(t => t.Reservations)
                .ToListAsync();

            return trainings;
        }

        public async Task DeleteAsync(int id)
        {
            var training = this.trainingRepository.GetById(id);

            if (training != null)
            {
                await trainingRepository.DeleteAsync(training);
            }
        }
        public async Task<Training> GetByIdAsync(int id)
        {
            return await trainingRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<TrainingsViewModel>> GetTrainingsBySportNameAsync(string sportName)
        {
            var trainings = await trainingRepository.GetAllAttached()
                .Where(t => t.Sport.Name.ToLower().Contains(sportName.ToLower()))
                .To<TrainingsViewModel>()
                .ToListAsync();

            return trainings;
        }
    }
}
