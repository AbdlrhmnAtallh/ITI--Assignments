using Day2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBindController : ControllerBase
    {
        public static List<Employee> Employees = new List<Employee>();
        [HttpPost("{e}")]
        public IActionResult Add(Employee e)
        {
            Employees.Add(e);
            return Ok("Employee has been Added");
        }
        [HttpPost]
        public IActionResult Fill()
        {
            for(int i = 10; i < 20; i++)
            {
                Employee e = new Employee();
                e.Id = i;
                e.Name = $"Employee {i}";
                e.Salary = i * i;
                e.DepartmentId = (i > 15) ? 1 : 2;
                Day2Entity.Employees.Add(e);
            }
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Day2Entity.Employees.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEmployee([FromRoute]int id, [FromBody] string name)
        {
            var e = Employees.FirstOrDefault(e => e.Id == id || e.Name == name);
            if (e == null)
            {
                return NotFound();
            }
            return Ok(e);
        }


    }
}
