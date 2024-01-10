using FinalProject_HRsystem.Services;
using Microsoft.AspNetCore.Mvc;
using FinalProject_HRsystem.Models.DepartmentINFO;
namespace FinalProject_HRsystem.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentLayer iDepartmentLayer;
        IEmployeeLayer iEmployeeLayer;
        public DepartmentController(IDepartmentLayer _iDepartmentLayer,IEmployeeLayer iEmployeeLayer)
        {
            iDepartmentLayer = _iDepartmentLayer;
            this.iEmployeeLayer = iEmployeeLayer;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Employees = iEmployeeLayer.All();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    iDepartmentLayer.Add(department);
                    return RedirectToAction("All", iDepartmentLayer.All());
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Employees = iEmployeeLayer.All().ToList();
            var department = iDepartmentLayer.GetDepartment(id);
            if(department == null)
            {
                // needs Notifiation 
                return View("All", iDepartmentLayer.All());
            }
            return View("Add",department);
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
            ViewBag.Employees = iEmployeeLayer.All();
            if (iDepartmentLayer.IsEmpty())
            {
                ModelState.AddModelError("", "No Departments yet!");
                // i'll use tosster Notifications here.
                // i want to redirect To the same action 
                return View(iDepartmentLayer.All());
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
        public IActionResult Fill()
        {
            ViewBag.Employees = iEmployeeLayer.All();
            iDepartmentLayer.Fill();
            return View("All", iDepartmentLayer.All());
        }

    }
}
