using Microsoft.AspNetCore.Mvc;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyContext db;
        public DepartmentController()
        {
            db = new CompanyContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult showDepartment()
        {
            var id = HttpContext.Session.GetInt32("id");
            var department = db.departments.SingleOrDefault(e => e.employeeid == id);
            
            return View(department);

        }
        public IActionResult displayDeptProjects()
        {
            var id = HttpContext.Session.GetInt32("id");

            var deptProjects = db.projects.Where(p => p.departmentid == p.department.id && p.department.employeeid == id);


            return View(deptProjects);
        }
        public IActionResult addToDeptProjectForm()
        {
            var id = HttpContext.Session.GetInt32("id");
            var allEmps = db.employees.ToList();
            var deptProjects = db.projects.Where(p => p.departmentid == p.department.id && p.department.employeeid == id);
            ViewBag.dps = deptProjects;
            return View(allEmps);
        }
        public IActionResult addToProject( int emp, List<int> projs)
        {
            foreach(var proj in projs)
            {
                WorksOn newobj = new WorksOn()
                {
                    employeeid = emp,
                    projectid = proj
                };
                db.workson.Add(newobj);
                db.SaveChanges();
            }

            return RedirectToAction("showDepartment");
        }
    }
}
