using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class ProjectController : Controller
    {
        CompanyContext db;
        public ProjectController()
        {
            db = new CompanyContext();
        }
        public IActionResult Index()
        {
            var projects = db.projects.ToList();
            return View(projects);
        }
        public IActionResult addProjectForm()
        {
            var depts = new SelectList(db.departments.ToList(), "id", "name");
            ViewBag.depts = depts;
            return View();
        }
        public IActionResult addProject(Project p)
        {
            db.projects.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult updateForm(int id)
        {
            var proj = db.projects.SingleOrDefault(d => d.id == id);
            var departList = new SelectList(db.departments.ToList(), "id", "name");
            ViewBag.list = departList;
            return View(proj);
        }
        public IActionResult updateProject(Project proj)
        {
            var oldproj = db.projects.SingleOrDefault(d => d.id == proj.id);
            oldproj.name = proj.name;
            oldproj.location = proj.location;
            oldproj.departmentid = proj.departmentid;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult deleteProject(int id)
        {
            var proj = db.projects.SingleOrDefault(d => d.id == id);
            db.projects.Remove(proj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
