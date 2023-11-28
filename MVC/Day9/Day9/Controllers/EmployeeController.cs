using Microsoft.AspNetCore.Mvc;

namespace Day9.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
        
    }
}
