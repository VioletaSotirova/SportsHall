using Microsoft.AspNetCore.Mvc;
using SportsHall.Data;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Web.ViewModels;

namespace SportsHall.Web.Controllers
{
    public class CoachController : Controller
    {
        private readonly ICoachService coachService;
        private readonly SportsHallDbContext dbContext;
        public CoachController(SportsHallDbContext dbContext, ICoachService coachService)
        {
            this.coachService = coachService;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<CoachesViewModel> coaches =
               await this.coachService.GetAllAsync();

            return View(coaches);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var coach = await this.coachService.DetailsAsync(id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }
    }
}
