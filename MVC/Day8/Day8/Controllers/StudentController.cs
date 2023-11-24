using Microsoft.AspNetCore.Mvc;
using Day8.Models;
using Day8.Services;

namespace Day8.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepository istudentRepository;// = new StudentRepository();
        public StudentController(IStudentRepository _istudentRepository)
        {
            istudentRepository = _istudentRepository;
        }
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
            istudentRepository.Add(student);
            return View("All",istudentRepository.All());
        }
        public IActionResult All()
        {
            return View(istudentRepository.All());
        }

        public IActionResult SaveD (Department d)
        {
            istudentRepository.SaveD(d);
            return View("All", istudentRepository.All());
        }
    }
}
