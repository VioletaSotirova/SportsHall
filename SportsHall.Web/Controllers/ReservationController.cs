using Microsoft.AspNetCore.Mvc;
using SportsHall.Services.Data;
using SportsHall.Services.Data.Interfaces;
using System.Security.Claims;

namespace SportsHall.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;
        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            var reservations = await reservationService.GetUserReservationsAsync(userId);

            return View(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(int trainingId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            await reservationService.SignUpAsync(trainingId, userId);

            return RedirectToAction("Index");
        }
    }
}
