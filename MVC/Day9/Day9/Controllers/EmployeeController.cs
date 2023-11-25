using Microsoft.AspNetCore.Mvc;

namespace Day9.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
