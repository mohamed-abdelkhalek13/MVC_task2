using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using System.Diagnostics;
using MVC2.Models;

namespace MVC2.Controllers
{
    
    public class HomeController : Controller
    {
        CompanyContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult userlogin(Employee emp)
        {
            db = new CompanyContext();

            var employee = db.employees.SingleOrDefault(e => e.id == emp.id);
            if (employee != null && employee.fname == emp.fname)
            {
                HttpContext.Session.SetInt32("id", employee.id);
                return RedirectToAction("userDetails", "Employee");
            } else
            {
                return Content("error");

            }


        }

    }
}