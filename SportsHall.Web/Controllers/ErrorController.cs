using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SportsHall.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult NotFoundError()
        {
            return View("NotFound");
        }

        [Route("Error/500")]
        public IActionResult InternalServerError()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exceptionDetails != null)
            {
                ViewData["ExceptionMessage"] = exceptionDetails.Error.Message;
                ViewData["StackTrace"] = exceptionDetails.Error.StackTrace;
            }
            return View("InternalServerError");
        }
    }
}
