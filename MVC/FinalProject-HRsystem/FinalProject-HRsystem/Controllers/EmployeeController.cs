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
                iemployeelayer.Add(employee);
                return RedirectToAction("All",iemployeelayer.All);
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
                if (iemployeelayer.Update(employee) !=0)
                {
                    return View("All", iemployeelayer.All());
                }
                ModelState.AddModelError("", "Something Went Wrong. Connect with me at abdlrhmntt@gmail.com");
            }
            return View("Add",employee);
        }
        public IActionResult All()
        {
            return View(iemployeelayer.All());
        }
        public IActionResult Delete(int id)
        {
            iemployeelayer.Delete(id);
            return View("All", iemployeelayer.All());
        }
        public IActionResult DeleteAll()
        {
            iemployeelayer.DeleteAll();
            return View("All", iemployeelayer.All());
        }
    }
}
