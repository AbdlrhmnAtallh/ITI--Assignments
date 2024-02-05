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
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Valid = true;
                    iTaskLayer.Add(task);
                    ViewBag.Employees = iEmployeeLayer.All().ToList();
                    return RedirectToAction("All", iTaskLayer.All());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewBag.Valid = false;// till we got a conection with DB
            ViewBag.Employees = iEmployeeLayer.All().ToList();
            return View(task);
        }

        public IActionResult All()
        {
            ViewBag.Employees = iEmployeeLayer.All().ToList();
            return View(iTaskLayer.All());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = iTaskLayer.GetOneTask(id);
            ViewBag.Employees = iEmployeeLayer.All();
            return View("Add",task);
        }
        [HttpPost]
        public IActionResult Edit(ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    iTaskLayer.Edit(task);
                    return RedirectToAction("All", iTaskLayer.All());
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View("Add",task);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                iTaskLayer.Delete(id);
                return RedirectToAction("All", iTaskLayer.All());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("All", iTaskLayer.All());
        }
    }
}
