using Microsoft.AspNetCore.Mvc;
using Day8.Models;
using Day8.Services;

namespace Day8.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Save(Student student)
        {
            StudentRepository studentRepository = new StudentRepository();
            studentRepository.Add(student);
            return View("All",studentRepository.All());
        }
        public IActionResult All()
        {
            StudentRepository studentRepository = new StudentRepository();
            return View(studentRepository.All());
        }
    }
}
