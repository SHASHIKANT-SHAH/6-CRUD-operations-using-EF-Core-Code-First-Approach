using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        AppDbContext _db;
        public EmployeeController(AppDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            var employees = _db.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _db.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model) 
        {
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                _db.Employees.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _db.Departments.ToList();
            return View();  
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Departments = _db.Departments.ToList();
            var employee = _db.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                _db.Employees.Update(model);
                //partial update
                //Product product = _db.Products.Find(model.EmployeeId);
                //product.Salay = model.Salary; //track dbcontext
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _db.Departments.ToList();
            return View();
        }

        public IActionResult Delete(int id)
        {
            var employee = _db.Employees.Find(id);
            if(employee != null)
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();  
        }
    }
}
