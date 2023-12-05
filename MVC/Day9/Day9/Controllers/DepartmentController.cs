using Day9.Models;
using Day9.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day9.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository idepartmentrepository;
        public DepartmentController (IDepartmentRepository _idepartmentrepository)
        {
            idepartmentrepository = _idepartmentrepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Save(Department d)
        {
            idepartmentrepository.Add(d);
            return Content("done");
        }
    }
}
