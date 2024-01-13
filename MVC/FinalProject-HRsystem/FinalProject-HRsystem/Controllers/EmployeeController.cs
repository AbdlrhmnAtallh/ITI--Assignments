using Microsoft.AspNetCore.Mvc;
using FinalProject_HRsystem.Models.EmployeeINFO;
using FinalProject_HRsystem.Services;

namespace FinalProject_HRsystem.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeLayer iemployeelayer;
        IDepartmentLayer idepartmentLayer;
       public EmployeeController(IEmployeeLayer _iemployeelayer, IDepartmentLayer idepartmentLayer)
        {
            iemployeelayer = _iemployeelayer;
            this.idepartmentLayer = idepartmentLayer;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Departments = idepartmentLayer.All();
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
            ViewBag.Departments = idepartmentLayer.All().ToList();
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
                    ViewBag.Departments = idepartmentLayer.All();
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
            ViewBag.Departments = idepartmentLayer.All();
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
        public IActionResult Fill()
        {
            iemployeelayer.Fill();
            return View("All", iemployeelayer.All());
        }
        public IActionResult Sort()
        {
            return View("All",iemployeelayer.Sort(iemployeelayer.All()));
        }
    }
}
