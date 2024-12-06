using Microsoft.EntityFrameworkCore;
using SportsHall.Data.Models;
using SportsHall.Data.Repository.Interfaces;

namespace SportsHall.Data.Repository
{
    public class ReservationRepository : BaseRepository<Reservation, int>, IReservationRepository
    {
        public ReservationRepository(SportsHallDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Reservation> GetReservationAsync(int trainingId, string userId)
        {
            var reservation = await dbContext.Reservations
                 .FirstOrDefaultAsync(r => r.UserId == int.Parse(userId) && r.TrainingId == trainingId);

            return reservation;
        }
        public async Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(string userId)
        {
            var reservations = await dbContext.Reservations
               .Where(r => r.UserId == int.Parse(userId))
               .Include(r => r.Training)
               .ThenInclude(t => t.Sport)
               .Include(r => r.Training.Coach)
               .ToListAsync();

            return reservations;
        }

        public async Task SignUpAsync(int trainingId, string userId)
        {
            var reservation = await GetReservationAsync(trainingId, userId);
            var training = await dbContext.Trainings.FirstOrDefaultAsync(t => t.Id == trainingId);

            if (reservation == null && training.AvailableSpot > 0)
            {
                Reservation newReservation = new Reservation()
                {
                    TrainingId = trainingId,
                    UserId = int.Parse(userId),
                    CreatedOn = DateTime.UtcNow
                };

                training.AvailableSpot = training.AvailableSpot - 1;

                await dbContext.Reservations.AddAsync(newReservation);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task CancelAsync(int reservationId)
        {
            var reservation = await GetByIdAsync(reservationId);

            var training = await dbContext.Trainings.FindAsync(reservation.TrainingId);

            training.AvailableSpot = training.AvailableSpot + 1;
            await DeleteAsync(reservation);
        }
    }
}
