using FinalProject_HRsystem.Services;
using Microsoft.AspNetCore.Mvc;
using FinalProject_HRsystem.Models.DepartmentINFO;
namespace FinalProject_HRsystem.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentLayer iDepartmentLayer;
        public DepartmentController(IDepartmentLayer _iDepartmentLayer)
        {
            iDepartmentLayer = _iDepartmentLayer;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                if (iDepartmentLayer.Add(department) == 0) 
                {
                    ModelState.AddModelError("", "Somthing Went Wrong");
                }
                else
                {
                    return RedirectToAction("All", iDepartmentLayer.All());
                }
                
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View("Add");
        }
        [HttpPost]
        public IActionResult Update (Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    iDepartmentLayer.Update(department);
                    return RedirectToAction("All", iDepartmentLayer.All());
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("",ex.Message);
                    return View(department);
                }
            }
            return View("Add",department);
        }
        public IActionResult All()
        {
            if (iDepartmentLayer.IsEmpty())
            {
                ModelState.AddModelError("", "No Departments yet!");
                // i'll use tosster Notifications here.
                // i want to redirect To the same action 
                return View();
            }
            return View(iDepartmentLayer.All());
        }
        
        public IActionResult Remove(int id)
        {
            try
            {
                iDepartmentLayer.Remove(id);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // needs to display in notification
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
