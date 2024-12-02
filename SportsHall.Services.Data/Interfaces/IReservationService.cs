using SportsHall.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHall.Services.Data.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationViewModel>> GetUserReservationsAsync(string userId);
        Task SignUpAsync(int trainingId, string userId);
    }
}
