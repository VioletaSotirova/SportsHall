using Microsoft.AspNetCore.Mvc;
using SportsHall.Services.Data.Interfaces;
using System.Data.Common;
using SportsHall.Data;
using SportsHall.Web.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace SportsHall.Web.Controllers
{
    public class SportController : Controller
    {
        private readonly ISportService sportService;
        private readonly SportsHallDbContext dbContext;
        private readonly ICoachService coachService;
        public SportController(SportsHallDbContext dbContext, ISportService sportService, ICoachService coachService)
        {
            this.sportService = sportService;
            this.dbContext = dbContext;
            this.coachService = coachService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<SportsViewModel> sports =
                await this.sportService.GetAllAsync();

            return View(sports);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var sport = await this.sportService.DetailsAsync(id);
            if (sport == null)
            {
                return NotFound();
            }

            return View(sport);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var sport = await this.sportService.EditAsync(id);

            if (sport == null)
            {
                return NotFound();
            }

            return View(sport);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SportEditViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableCoaches = await coachService.GetAllCoachesAsSelectListAsync();

                if (model.SelectedCoaches != null)
                {
                    model.SelectedCoachesNames = await coachService.GetCoachNamesByIdsAsync(model.SelectedCoaches);
                }

                return View(model);
            }

            await sportService.UpdateSportAsync(model);
            return RedirectToAction("Index");
        }


    }
}

