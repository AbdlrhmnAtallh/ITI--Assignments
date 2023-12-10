using Day9.Models;
using Day9.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day9.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository employeeRepository;
        public EmployeeController (IEmployeeRepository _employeeRepository)
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

        [Authorize]
        public IActionResult Auth()
        {
            return View();
        }
        
    }
}
 