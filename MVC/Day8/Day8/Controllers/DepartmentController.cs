using Microsoft.AspNetCore.Mvc;
using Day8.Services;
using Day8.Models;

namespace Day8.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository idepartmentRepository;
        public DepartmentController(IDepartmentRepository _idepartmentRepository)
        {
            idepartmentRepository = _idepartmentRepository;
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Save (Department department)
        {
            idepartmentRepository.Add(department);
            return View("All",idepartmentRepository.All());
        }
        public IActionResult All()
        {
            return View(idepartmentRepository.All());
        }
    }
}
