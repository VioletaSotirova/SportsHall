using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsHall.Services.Data.Interfaces;

using SportsHall.Web.ViewModels;



namespace SportsHall.Web.Controllers
{
    public class SportController : Controller
    {
        private readonly ISportService sportService;

        public SportController(ISportService sportService)
        {
            this.sportService = sportService;
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(SportEditViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await sportService.UpdateSportAsync(model);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var sport = await sportService.GetByIdAsync(id);

            if (sport == null)
            {
                return NotFound(); 
            }
            await sportService.DeleteAsync(sport.Id);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new SportEditViewModel();
            return View(model);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(SportEditViewModel model)
        {
            var existingSport = await sportService.GetByIdAsync(model.Id);
            if (existingSport != null)
            {
                ModelState.AddModelError("Name", "Спорт с такова име вече съществува.");
            }
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await sportService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}

