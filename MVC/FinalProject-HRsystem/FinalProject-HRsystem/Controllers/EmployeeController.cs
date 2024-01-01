using Microsoft.AspNetCore.Mvc;
using FinalProject_HRsystem.Models.EmployeeINFO;
using FinalProject_HRsystem.Services;

namespace FinalProject_HRsystem.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeLayer iemployeelayer;
       public EmployeeController(IEmployeeLayer _iemployeelayer)
       {
           iemployeelayer = _iemployeelayer;
       }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    iemployeelayer.Add(employee);
                    return RedirectToAction("All", iemployeelayer.All());
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("",ex.Message);
                }
               
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Update(int  id)
        {
            var item = iemployeelayer.GetAnEmployee(id);
            return View("Add",item);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    iemployeelayer.Update(employee);
                    return View("All", iemployeelayer.All());
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View("Add",employee);
        }
        public IActionResult All()
        {
            if (iemployeelayer.All() == null)
            {
                return View("EmptyList");
            }
            return View(iemployeelayer.All());
        }
        public IActionResult Delete(int id)
        {
            try
            {
                iemployeelayer.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            
            return View("All", iemployeelayer.All());
        }
        public IActionResult DeleteAll()
        {
            iemployeelayer.DeleteAll();
            return View("All", iemployeelayer.All());
        }
    }
}
