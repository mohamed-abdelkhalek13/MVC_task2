using Microsoft.AspNetCore.Mvc;

namespace MVC2.Controllers
{
    public class CustomValidationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult validateLocation (string location)
        {
            if (location == "cairo" || location == "giza" || location == "alex")
            {
                return Json(true);
            } else
            {
                return Json(false);
            }

        }
    }
}
