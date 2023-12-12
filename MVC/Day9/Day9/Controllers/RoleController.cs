using Day9.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Day9.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        [Authorize(Roles = "Admin")] // Auth & Author
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                // Mapping 
                IdentityRole role = new IdentityRole()
                {
                    Name = roleViewModel.Name
                };
                
                // Create role And add the Result in IdentityResult
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Auth", "Registration");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(roleViewModel);
        }

        public IActionResult All()
        {
            var AllRoles = roleManager.Roles.ToList();
           // List<string> Roles = new List<string>();
            ViewBag.Roles = AllRoles;
            //foreach(var item in roleManager.Roles)
            //{
            //    AllRoles.Add(item);
            //}
            return View();
        }

    }
}
