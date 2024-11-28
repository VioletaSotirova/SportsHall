using Microsoft.AspNetCore.Mvc;
using SportsHall.Data;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Web.ViewModels;

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
            IEnumerable<TrainingsViewModel> trainings =
              await this.trainingService.GetAllAsync();

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
                trainingService.GetCreateTrainingViewModel();
                return this.View(model);
            }

            await trainingService.CreateAsync(model);

            return RedirectToAction("Index");
        }
    }
}
