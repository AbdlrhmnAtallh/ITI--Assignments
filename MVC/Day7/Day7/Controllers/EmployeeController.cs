using Microsoft.AspNetCore.Mvc;
using Day7.Models;
namespace Day7.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<Employee> Employees = new List<Employee>();
        
        public IActionResult NameExists(string Name)
        {
            var employee = Employees.FirstOrDefault(x => x.Name == Name);
            if (employee == null)
            {
                return Json(true);
            }
            return Json(false);
        }

        public IActionResult CityLetters(string City)
        {
            if (City.Length < 5)
            {
                return Json(false);
            }
            else 
                return Json(true);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Save( Employee e)
        {
            if (ModelState.IsValid)
            {
                Employees.Add(new Employee { Id = e.Id, Name = e.Name , City =e.City});
                Employee.Employees.Add(new Employee { Id = e.Id, Name = e.Name, City = e.City });
                return View("All",Employees);
            }
            return View("Add");
        }
        public IActionResult All()
        {
            return View(Employees);
        }
    }
}
