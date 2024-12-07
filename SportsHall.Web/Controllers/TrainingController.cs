using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SportsHall.Data;
using SportsHall.Data.Models;
using SportsHall.Services.Data;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Web.ViewModels;
using System.Security.Claims;

namespace SportsHall.Web.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingService trainingService;
        public TrainingController(ITrainingService trainingService)
        {
            this.trainingService = trainingService;
       
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<TrainingsViewModel> trainings =
              await this.trainingService.GetAllAsync(userId);

            return View(trainings); 
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TrainingCreateViewModel model = await trainingService.GetCreateTrainingViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrainingCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await trainingService.GetCreateTrainingViewModel();

                return this.View(model);
            }

            await trainingService.CreateAsync(model);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var training = await trainingService.EditAsync(id);

            if (training == null)
            {
                return NotFound();
            }
                   
            return View(training);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TrainingCreateViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model = await trainingService.GetCreateTrainingViewModel();
                return View(model);
            }

            await trainingService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var training = await trainingService.GetByIdAsync(id);

            if (training == null)
            {
                return NotFound();
            }
            await trainingService.DeleteAsync(training.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Search(string sportName)
        {
            if (string.IsNullOrWhiteSpace(sportName))
            {
                return View("Index", new List<TrainingsViewModel>());
            }

            var trainings = await trainingService.GetTrainingsBySportNameAsync(sportName);
            return View("Index", trainings);
        }
    }
}
