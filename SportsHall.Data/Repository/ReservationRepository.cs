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
                .AsNoTracking()
                 .FirstOrDefaultAsync(r => r.UserId == int.Parse(userId) && r.TrainingId == trainingId);

            return reservation;
        }
        public async Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(string userId)
        {
            var reservations = await dbContext.Reservations
                .AsNoTracking()
               .Where(r => r.UserId == int.Parse(userId))
               .Include(r => r.Training)
               .ThenInclude(t => t.Sport)
               .Include(r => r.Training.Coach)
               .ToListAsync();

            return reservations;
        }
    }
}
