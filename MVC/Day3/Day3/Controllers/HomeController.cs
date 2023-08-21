using Day3.Models;
using Day3.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

       
        
        public IActionResult Students()
        {
            // Adding Values 
            List<Student> StudentsList = new List<Student>()
            {
                new Student(){Id = 1 , Name="StudentA",CourseId=100},
                new Student(){Id = 2 , Name="StudentB",CourseId=101},
                new Student(){Id = 3 , Name="StudentC",CourseId=102},
                new Student(){Id = 4 , Name="StudentD",CourseId=100},
            };
            List<Course> CoursesList = new List<Course>()
            {
                new Course(){Id = 101 , Name = "ASP.Net Mvc "},
                new Course(){Id = 100 , Name = "C#"},
                new Course(){Id = 102 , Name = "Entity FrameWork"}
            };


           List<StudentsWithCoursesViewModel> studentsWithCourses = new List<StudentsWithCoursesViewModel>();
            foreach(var item in StudentsList)
            {
                studentsWithCourses.Add(new StudentsWithCoursesViewModel() { StudentName = item, CourseName = CoursesList.FirstOrDefault(s => s.Id == item.CourseId) });
            }
            
            return View(studentsWithCourses);
        }




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}