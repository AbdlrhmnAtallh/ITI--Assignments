using Microsoft.AspNetCore.Mvc;

namespace FinalProject_HRsystem.Controllers
{
    public class TaskController : Controller
    {
       public IActionResult Add()
       {
           return View();
       }
    }
}
