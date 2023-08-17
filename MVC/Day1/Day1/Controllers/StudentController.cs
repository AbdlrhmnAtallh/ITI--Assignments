using Day1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {

            var STL = StudentList.Students;
            return View("AllStudent",STL);

        }
        public IActionResult DisplayOneStudent(int id)
        {
            Student s = StudentList.Students.FirstOrDefault(e => e.Id == id);
            return View("DisplayOneStudent",s);
        }
        
    }
}
