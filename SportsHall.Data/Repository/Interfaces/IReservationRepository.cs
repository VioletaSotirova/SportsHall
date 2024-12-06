using SportsHall.Data.Models;

namespace SportsHall.Data.Repository.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation, int>
    {
        Task<Reservation> GetReservationAsync(int trainingId, string userId);
        Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(string userId);
        Task SignUpAsync(int trainingId, string userId);
        Task CancelAsync(int reservationId);
    }
}
