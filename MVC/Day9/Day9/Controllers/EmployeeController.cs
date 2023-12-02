using Day9.Models;
using Day9.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day9.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository employeeRepository;
        public EmployeeController (EmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            employeeRepository.Add(employee);
            return View("All", employeeRepository.All());
        }
        public IActionResult All()
        {
            return View(employeeRepository.All());
        }
        
    }
}
