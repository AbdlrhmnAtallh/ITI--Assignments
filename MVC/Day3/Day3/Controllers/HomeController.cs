using Day3.Models;
using Day3.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            List<Student> LL = Student.StudentsList;
            LL.Add(new Student() { Id = 3, Name = "StudentC" });
            var ii = Instructor.InstructorList;
            ii.Add(new Instructor() { Id = 3, Name = "InstructorC" });


            StudentNameWithInstructorNameViewModel StudentInstructor
                = new StudentNameWithInstructorNameViewModel();



            return View(ii);
        }

        public IActionResult Privacy()
        {
            var instructors = Instructor.InstructorList;
            instructors.Add(new Instructor() { Id = 3, Name = "InstructorC" });

            return View(instructors);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}