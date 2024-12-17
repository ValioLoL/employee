using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    
        public class employeController : Controller
        {
            private readonly ApplicationDbContext db;

            public employeController(ApplicationDbContext db)
            {
                this.db = db;
            }
            public IActionResult Index()
            {
                return View();
            }
            public IActionResult Add()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Add(employeeViewModel model)
            {
                employee employee = new employee
                {
                    Name = model.Name,
                    ID = model.ID,
                    Salary = model.Salary,
                    Position = model.Position,
                };
                db.employees.Add(employee);
                db.SaveChanges();
                return Redirect("/Home/Index");
            }
            public IActionResult Details(int id)
            {
                employee employee = db.employees.FirstOrDefault(c => c.Id == id);
                employeeViewModel model = new employeeViewModel
                {
                    Name = employee.Name,
                    ID = employee.ID,
                    Salary = employee.Salary,
                    Position = employee.Position,
                };
                return View(model);
            }
            public IActionResult All()
            {
                List<employeeViewModel> model = db.employee.Select(x => new employeeViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Salary = x.Salary,
                    Position = x.Position,
                }).ToList();
                return View(model);
            }
        }
    }


