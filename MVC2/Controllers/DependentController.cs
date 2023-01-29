using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
namespace MVC2.Controllers
{
    public class DependentController : Controller
    {
        CompanyContext db;
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult showDependents()
        {
            db = new CompanyContext();
            var id = HttpContext.Session.GetInt32("id");
            var dependents = db.dependents.Where(e => e.employeeid == id).ToList();

            return View(dependents);

        }
        public IActionResult addDependentform()
        {
            var id = HttpContext.Session.GetInt32("id");
            TempData["msg"] = "dependent added successfully";

            return View("dependentForm", id);

        }
        public IActionResult AddDependent(Dependent dependent)
        {
            db = new CompanyContext();

            var id = HttpContext.Session.GetInt32("id");
            var dependentlist = db.dependents.Where(e => e.employeeid == id).ToList();
            db.dependents.Add(dependent);
            db.SaveChanges();
            return RedirectToAction("showDependents");
        }
        public IActionResult updateDependent(int id, string name)
        {
            db = new CompanyContext();
            var sid = HttpContext.Session.GetInt32("id");
            var dependent = db.dependents.Where(s => s.employeeid == sid && s.name == name).SingleOrDefault();
            TempData["msg"] = "dependent updated successfully";

            return View(dependent);
        }
        public IActionResult updateDependentInfo(Dependent dep)
        {
            db = new CompanyContext();
            var oldDependent = db.dependents.SingleOrDefault(s => s.employeeid == dep.employeeid && s.name == dep.name);
            oldDependent.name = dep.name;
            oldDependent.sex = dep.sex;
            oldDependent.employeeid = dep.employeeid;
            oldDependent.birthday = dep.birthday;
            oldDependent.relationship = dep.relationship;
            db.SaveChanges();

            return RedirectToAction("showDependents");
        }
        public IActionResult delete(int id)
        {
            db = new CompanyContext();
            var sid = HttpContext.Session.GetInt32("id");

            var dependent = db.dependents.SingleOrDefault(s => s.employeeid == sid && s.order == id);
            db.dependents.Remove(dependent);
            db.SaveChanges();
            TempData["msg"] = "dependent deleted successfully";
            return RedirectToAction("showDependents");
        }
    }
}
