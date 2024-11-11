using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SportsHall.Data;
using SportsHall.Web.ViewModels;
using SportsHall.Services.Data.Interfaces;

namespace SportsHall.Web.Controllers
{
    public class SportController : Controller
    {
        private readonly SportsHallDbContext context;
        private readonly ISportService sportService;
        public SportController(SportsHallDbContext context, ISportService sportService)
        {
            this.context = context;
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
            var sports = await this.context.Sports
                .Where(s => s.Id == id)
                .AsNoTracking()
                .ToListAsync();

            return Json(sports);
        }

    }
}
