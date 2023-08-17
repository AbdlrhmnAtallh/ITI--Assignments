using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id )
        {

            return View();
        }

    }
}
