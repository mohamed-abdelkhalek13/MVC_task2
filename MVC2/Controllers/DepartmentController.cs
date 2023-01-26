using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult displayDepartments()
        {
            var depts = db.departments.ToList();
            return View(depts);
        }
        public IActionResult addDepartmentForm()
        {
            
            var empsList = new SelectList(db.employees.ToList(), "id", "fname");

            return View(empsList);
        }
        public IActionResult addDepartment(Department dept)
        {
            db.departments.Add(dept);
            db.SaveChanges();
            return RedirectToAction("displayDepartments");
        }
        public IActionResult updateForm(int id)
        {
            var dept = db.departments.SingleOrDefault(d => d.id == id);
            var empsList = new SelectList(db.employees.ToList(), "id", "fname");
            ViewBag.list = empsList;
            return View(dept);
        }
        public IActionResult updateDepartment(Department dept)
        {
            var oldDept = db.departments.SingleOrDefault(d => d.id == dept.id);
            oldDept.name = dept.name;
            oldDept.location = dept.location;
            oldDept.startDate = dept.startDate;
            oldDept.employeeid = dept.employeeid;
            db.SaveChanges();
            return RedirectToAction("displayDepartments");
        }
        public IActionResult deleteDepartment(int id)
        {
            var dept = db.departments.SingleOrDefault(d => d.id == id);
            db.departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("displayDepartments");
        }
    }
}
