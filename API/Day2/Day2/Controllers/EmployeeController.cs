using Day2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Entity
namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
          //  List<Employee> empwithdept = Day2Entity.Employees.Join(e=>e.De)
            return Ok(Day2Entity.Employees.ToList());
        }
    }
}
