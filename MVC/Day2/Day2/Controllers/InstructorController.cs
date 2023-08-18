using Day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    public class InstructorController : Controller
    {
        
        public IActionResult Index()
        {
            List<Instructor> instrctor = InstructorList.instructorsList.ToList();
            return View(instrctor);
        }

        public IActionResult Detail(int id )
        {
            var item = InstructorList.instructorsList.FirstOrDefault( x => x.Id == id );
            return View(item);
        }


    }
}
