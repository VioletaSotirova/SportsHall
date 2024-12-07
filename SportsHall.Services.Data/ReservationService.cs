using Microsoft.EntityFrameworkCore;
using SportsHall.Data.Models;
using SportsHall.Data.Repository.Interfaces;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Web.ViewModels;
using SportsHall.Services.Mapping;

namespace SportsHall.Services.Data
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository reservationRepository;
        public ReservationService(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
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
