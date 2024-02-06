using Microsoft.AspNetCore.Mvc;
using FinalProject_HRsystem.Models.EmployeeINFO;
using FinalProject_HRsystem.Services;

namespace FinalProject_HRsystem.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeLayer iemployeelayer;
        IDepartmentLayer idepartmentLayer;
        ITaskLayer itaskLayer;
       public EmployeeController(IEmployeeLayer _iemployeelayer, IDepartmentLayer idepartmentLayer,ITaskLayer _iTaskLayer)
        {
            iemployeelayer = _iemployeelayer;
            this.idepartmentLayer = idepartmentLayer;
            itaskLayer = _iTaskLayer;
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
                    ViewBag.Departments = idepartmentLayer.All();
                    return RedirectToAction("All", iemployeelayer.All());
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("",ex.Message);
                }
               
            }
            ViewBag.Departments = idepartmentLayer.All();
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
                    return RedirectToAction("All", iemployeelayer.All());
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewBag.Departments = idepartmentLayer.All();
            return View("Add",employee);
        }
        public IActionResult All()
        {
            if (iemployeelayer.All() == null)
            {
                return View("EmptyList");
            }
            ViewBag.Tasks = itaskLayer.All();
            ViewBag.Departments = idepartmentLayer.All().ToList();
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
            ViewBag.Departments = idepartmentLayer.All();
            return RedirectToAction("All", iemployeelayer.All());
        }
        [HttpGet]
        public IActionResult DeleteAll()
        {
            iemployeelayer.DeleteAll();
            ViewBag.Departments = idepartmentLayer.All();
            return RedirectToAction("All", iemployeelayer.All());
        }
        
        public IActionResult Sort()
        {
            ViewBag.Departments = idepartmentLayer.All();
            return RedirectToAction("All",iemployeelayer.Sort(iemployeelayer.All()));
        }

        public IActionResult NameExists(string name,int id )
        {
            var employee =
                iemployeelayer.All().FirstOrDefault(e => e.Name == name);
            if (employee == null) { return Json(true); }
            if (employee != null && employee.Id == id)
            {
                return Json(true);
            }
            //var NewEmployeeRecord =
            //    iemployeelayer.All().FirstOrDefault(e => e.Id == id);
            //if (NewEmployeeRecord == null) // new Record With valid name
            //{
            //    return Json(true);
            //}
            return Json(false);
                
            
        }
    }
}
