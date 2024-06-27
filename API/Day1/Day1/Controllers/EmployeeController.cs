using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day1.Models;
namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> Employees = new List<Employee>();

        // POST api/Employee
        [HttpPost]
        public IActionResult Add([FromBody] Employee employee)
        {
            Employees.Add(employee);
            return Ok("Employee has been added");
        }

        // GET api/Employee/1
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            var e = Employees.FirstOrDefault(e => e.Id == id);
            if (e == null)
            {
                return BadRequest("No id has matched");
            }
            return Ok(e); // Ok is a status code in head and e is json code in body
        }

        // GET api/Employee/name/John
        [HttpGet]
        [Route("name/{name:alpha}")]
        public IActionResult GetEmployeeByName([FromRoute] string name)
        {
            Employee e = Employees.FirstOrDefault(e => e.Name == name);
            if (e == null)
            {
                return BadRequest("No Employee has this name");
            }
            return Ok(e);
        }

        // GET api/Employee/all
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            return Ok(Employees.ToList());
        }
    }
}

