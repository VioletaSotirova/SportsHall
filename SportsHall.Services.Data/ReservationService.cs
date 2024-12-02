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
            var reservation = await reservationRepository.GetReservationAsync(trainingId, userId);

            var training = await trainingService.GetByIdAsync(trainingId);

            if (reservation == null && training.AvailableSpot > 0)
            {
                Reservation newReservation = new Reservation()
                {
                    TrainingId = trainingId,
                    UserId = int.Parse(userId),
                    CreatedOn = DateTime.UtcNow
                };

                training.AvailableSpot = training.AvailableSpot - 1;
                await reservationRepository.AddAsync(newReservation);
            }
        }
        public async Task CancelAsync(int trainingId,string userId)
        {
            var reservation = await reservationRepository.GetReservationAsync(trainingId, userId);
            var training = await trainingService.GetByIdAsync(trainingId);

            training.AvailableSpot = training.AvailableSpot + 1;
            await reservationRepository.DeleteAsync(reservation);
        }
    }
}
