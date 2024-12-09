using Microsoft.AspNetCore.Mvc;

namespace SportsHall.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
