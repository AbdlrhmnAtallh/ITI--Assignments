using Day6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day6.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult AllEmployees()
        {
            DepartmentList D = new DepartmentList();
            ViewBag.Dept = D.Departments.ToList();

            return View(Employee.Employees);
        }

        public IActionResult AddEmployee()
        {
          
            DepartmentList D = new DepartmentList();
            ViewBag.Dept = D.Departments.ToList(); 
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewEmployee(Employee e)
        {
            if (ModelState.IsValid) 
            {
                Employee.Employees.Add(new Employee { Id = e.Id, Name = e.Name,Age = e.Age, Dept = e.Dept });
                return RedirectToAction("AllEmployees");
            }
            if(e.Age == 22)
            {
                ModelState.AddModelError("first year", "this your first year");
            }
            DepartmentList D = new DepartmentList();
            ViewBag.Dept = D.Departments.ToList();

        
            return View("AddEmployee", e);

            

        }

        public IActionResult Edit(int id)
        {
            var e = Employee.Employees.FirstOrDefault(e => e.Id == id);
            DepartmentList D = new DepartmentList();
            ViewBag.Dept = D.Departments.ToList();
           // return View("AddEmployee",e);
            return View("AddEmployee",e);
        }
        public IActionResult SaveEdit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var i = Employee.Employees.FirstOrDefault(e => e.Id == emp.Id);
                i.Name = emp.Name;
                i.Dept = emp.Dept;
                return RedirectToAction("AllEmployees");
            }
            return View("AddEmployee", emp);
        }

        public IActionResult FillList()
        {
           Employee.Employees.Add(new Employee { Id = 1, Name = "Employee1",Age=24, Dept = 3 });
           Employee.Employees.Add(new Employee { Id = 2, Name = "Employee2",Age=24, Dept = 2 });
           Employee.Employees.Add(new Employee { Id = 3, Name = "Employee3",Age=24, Dept = 1 });
           Employee.Employees.Add(new Employee { Id = 4, Name = "Employee4",Age=24, Dept = 3 });
           Employee.Employees.Add(new Employee { Id = 5, Name = "Employee5",Age=24, Dept = 1 });
           Employee.Employees.Add(new Employee { Id = 6, Name = "Employee6",Age=24, Dept = 2 });
           Employee.Employees.Add(new Employee { Id = 7, Name = "Employee7",Age=24, Dept = 2 });
           Employee.Employees.Add(new Employee { Id = 8, Name = "Employee8",Age=24, Dept = 3 });
           Employee.Employees.Add(new Employee { Id = 9, Name = "Employee9",Age=24, Dept = 1 });

            return RedirectToAction("AllEmployees");
        }
    
    }
}
