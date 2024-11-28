using Microsoft.AspNetCore.Mvc;
using SportsHall.Data;
using SportsHall.Services.Data;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Web.ViewModels;

namespace SportsHall.Web.Controllers
{
    public class CoachController : Controller
    {
        private readonly ICoachService coachService;  
        public CoachController(ICoachService coachService)
        {
            this.coachService = coachService;
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var coach = await this.coachService.EditAsync(id);

            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CoachEditViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await coachService.UpdateCoachAsync(model);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CoachEditViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CoachEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await coachService.CreateAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var coach = await coachService.GetCoachByIdAsync(id);

            if (coach == null)
            {
                return NotFound();
            }
            await coachService.DeleteAsync(coach.Id);

            return RedirectToAction(nameof(All));
        }

    }
}
