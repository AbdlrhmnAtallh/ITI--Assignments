using Microsoft.AspNetCore.Mvc;
using Day7.Models;
//using AspNetCore;

namespace Day7.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<Employee> Employees = new List<Employee>();

        public static int[] Ids = new int[10];
        public static string[] Names = new string[10];
        int List = 0;


        public IActionResult NameExists(string Name , int id )
        {
            Employee e = Employees.FirstOrDefault(i => i.Id == id);
            bool IdEqual0 = false;
            if(e == null)
            {
                IdEqual0 = true; // id eqaul true so this is a new record 
            }
            if (IdEqual0) // new record
            {
                var employee = Employees.FirstOrDefault(x => x.Name == Name);
                if (employee == null) // new record with a non-repeating name
                {
                    return Json(true); 
                }
                return Json(false);// new record with a dublicate name
            }
            else // Editing an existing record
            {
                var employee = Employees.FirstOrDefault(x => x.Name == Name);
                if (employee == null) // Valid new name
                {
                    return Json(true);
                }

                if(employee.Id == id) // Duplicate Name but with the same id 
                {
                    return Json(true);
                }
                return Json(false); // Not Valid Name
            }
        }

        public IActionResult TestAjax()
        {
            return View();
        }
        public IActionResult TestPartial()
        {
            return PartialView("DisplayInCards",Employees);
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
               
                return View("All",Employees);
            }
            return View("Add",e);
        }
        public IActionResult All()
        {
            return View(Employees);
        }

        public IActionResult Edit(int id)
        {
            Employee e = Employees.FirstOrDefault(i => i.Id == id);
            return View(e);
        }
        public IActionResult SaveEdit(Employee e)
        {
            if (ModelState.IsValid)
            {
                Employee emp = Employees.FirstOrDefault(i=>i.Id == e.Id);
                emp.Id = e.Id;
                emp.Name = e.Name;
                emp.City = e.City;
                return View("All",Employees);
            }
            return View("Edit", e);
        }
        public IActionResult Delete(int id)
        {
            var EmployeeToRemove = Employees.FirstOrDefault(e => e.Id == id);
            if (EmployeeToRemove != null)
            {
                Employees.Remove(EmployeeToRemove);
                return RedirectToAction("All");
            }
            else
                return NotFound();


        }
    }
}
