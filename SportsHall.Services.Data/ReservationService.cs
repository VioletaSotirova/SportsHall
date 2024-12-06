using Microsoft.EntityFrameworkCore;
using SportsHall.Data.Models;
using SportsHall.Data.Repository.Interfaces;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Web.ViewModels;

namespace SportsHall.Services.Data
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository reservationRepository;
        private ITrainingService trainingService;
        public ReservationService(IReservationRepository reservationRepository, ITrainingService trainingService)
        {
            this.reservationRepository = reservationRepository;
            this.trainingService = trainingService;
        }

        public async Task<IEnumerable<ReservationViewModel>> GetUserReservationsAsync(string userId)
        {
            var reservations = await reservationRepository.GetReservationsByUserIdAsync(userId);

            var models = reservations.Select(r => new ReservationViewModel
            {
                Id = r.Id,
                TrainingId = r.TrainingId,
                SportName = r.Training.Sport.Name,
                CoachName = $"{r.Training.Coach.FirstName} {r.Training.Coach.LastName}",
                Start = r.Training.Start,
                Location = r.Training.Location,
                CreatedOn = r.CreatedOn
            });

            return models;
        }

        public async Task SignUpAsync(int trainingId, string userId)
        {
            await reservationRepository.SignUpAsync(trainingId, userId);
        }
        public async Task CancelAsync(int reservationId)
        {
            await reservationRepository.CancelAsync(reservationId);
        }
    }
}
