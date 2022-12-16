using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        AppDbContext _db;
        public DepartmentController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var departments = _db.Departments.ToList();
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(ModelState.IsValid)
            {
                _db.Departments.Add(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Department department = _db.Departments.Find(id);
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if(ModelState.IsValid)
            {
                _db.Departments.Update(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id) 
        {
            Department department = _db.Departments.Find(id);

           if(department!= null)
            {
                _db.Departments.Remove(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
