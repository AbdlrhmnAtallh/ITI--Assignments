using Day2.Models;
using Day2.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            // Employee e = Day2Entity.Employees.Include(e=>e.Department)
            //                .FirstOrDefualt(e=>e.Id==id)

            EmployeeDataWithDepartmentName EmployeeDatawithdptname = new EmployeeDataWithDepartmentName();
            // EmployeeDatawithdptname.studName = e.Name;
            // EmployeeDatawithdptname.deptName = e.Department;
            return Ok(Day2Entity.Employees.ToList());
        }
    }
}
