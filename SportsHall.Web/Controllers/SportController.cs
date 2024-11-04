using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsHall.Data;
using SportsHall.Web.ViewModels;

namespace SportsHall.Web.Controllers
{
    public class SportController : Controller
    {
        private readonly SportsHallDbContext context;
        public SportController(SportsHallDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sports = await this.context
                .Sports
                .AsNoTracking()
                .Select(s => new SportsViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Image = s.ImageUrl
                })
                .ToListAsync();
                
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
