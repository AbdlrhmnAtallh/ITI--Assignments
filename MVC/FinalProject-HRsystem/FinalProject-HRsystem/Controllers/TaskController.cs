using Microsoft.AspNetCore.Mvc;
using FinalProject_HRsystem.Services;
using FinalProject_HRsystem.Models.TaskINFO;

namespace FinalProject_HRsystem.Controllers
{
    public class TaskController : Controller
    {
        ITaskLayer iTaskLayer;
        IEmployeeLayer iEmployeeLayer;
        public TaskController(ITaskLayer iTaskLayer,IEmployeeLayer iEmployeeLayer)
        {
            this.iTaskLayer = iTaskLayer;
            this.iEmployeeLayer = iEmployeeLayer;
        }

        [HttpGet]
       public IActionResult Add()
       {
            ViewBag.Employees = iEmployeeLayer.All().ToList();
           return View();
       }
        [HttpPost]
        public IActionResult Add(ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                iTaskLayer.Add(task);
                return View("All", iTaskLayer.All());
            }
            return View(task);
        }

        public IActionResult All()
        {
            return View(iTaskLayer.All());
        }
    }
}
