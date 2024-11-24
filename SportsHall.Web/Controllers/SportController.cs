using Microsoft.AspNetCore.Mvc;
using SportsHall.Services.Data.Interfaces;

using SportsHall.Data;
using SportsHall.Web.ViewModels;
using SportsHall.Data.Models;
using System.Globalization;
using System.Runtime.Serialization;
using static SportsHall.Common.EntityValidationConstants;


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
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var sport = await sportService.GetByIdWithCoachesAsync(id);

            if (sport == null)
            {
                return NotFound(); 
            }

            sport.SportsCoaches.Clear();
            await sportService.DeleteAsync(sport.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new SportEditViewModel();
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(SportEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableCoaches = await coachService.GetAllCoachesAsSelectListAsync();
                return this.View(model);
            }

            await sportService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

    }
}

