using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2.Models;
namespace MVC2.Controllers
{
    
    public class EmployeeController : Controller
    {
        CompanyContext db;
        public EmployeeController()
        {
            db = new CompanyContext();
        }
        public IActionResult Index()
        {
            var employessList = db.employees.ToList();

            return View(employessList);
        }
        public IActionResult employeeDetails(int id)
        {
            var empDetails = db.employees.SingleOrDefault(s => s.id == id);
            if(empDetails == null)
            {
                return View("errorpage");
            }
            else
            {
                return View(empDetails);
            }
        }
        public IActionResult userDetails()
        {
            var id = HttpContext.Session.GetInt32("id");
            var Details = db.employees.SingleOrDefault(s => s.id == id);
            if (Details.id == Details.supervisorid)
            {
                return View("mngrDetails", Details);
            }
            else
            {
                return View(Details);
            }
        }


        public IActionResult addemployeeform()
        {
            var employessList = db.employees.ToList();
            return View(employessList);

        }
        public IActionResult AddEmployee(Employee emp)
        {
            db.employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult updateEmployee(int id)
        {
            var emp = db.employees.SingleOrDefault(s => s.id == id);
            var supervisors = db.employees.ToList();
            ViewBag.all = supervisors;
            return View(emp);
        }
        public IActionResult updateEmployeeInfo(Employee emp)
        {
            var oldEmp = db.employees.SingleOrDefault(s => s.id == emp.id);
            oldEmp.fname = emp.fname;
            oldEmp.minit = emp.minit;
            oldEmp.sex = emp.sex;
            oldEmp.salary = emp.salary;
            oldEmp.birthday = emp.birthday;
            oldEmp.address = emp.address;
            oldEmp.supervisorid = emp.supervisorid;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult delete(int id)
        {
            var emp = db.employees.SingleOrDefault(s => s.id == id);
            db.employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult employeeProjectsHours()
        {
            ViewBag.empsList = new SelectList(db.employees.Select(s => new { s.id, fullName = s.fname + " " + s.lname }).ToList(), "id", "fullName");
            return View();
        }
        public IActionResult getProjects(int id)
        {
            var projs = db.workson.Include(s => s.employee).Include(s => s.project).Where(s => s.employeeid == id).Select(s => s.project).ToList();
            ViewBag.projsList = new SelectList(projs, "id", "name");
            return PartialView("_getProjects");
        }
        public IActionResult getHours(int id, int name)
        {
            var works = db.workson.SingleOrDefault(w => w.employeeid == id && w.projectid == name);
            return PartialView("_getHours", works);
        }
        public IActionResult updateHours(WorksOn w)
        {
            var wOn = db.workson.SingleOrDefault(s => s.employeeid == w.employeeid && s.projectid == w.projectid);
            wOn.hours = w.hours;
            db.SaveChanges();
            return RedirectToAction("employeeProjectsHours");
        }
    }

}
