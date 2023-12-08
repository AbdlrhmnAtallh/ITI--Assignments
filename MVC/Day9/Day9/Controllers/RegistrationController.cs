using Microsoft.AspNetCore.Mvc;
using Day9.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace Day9.Controllers
{
    public class RegistrationController : Controller
    {
        //RegisterAccountViewModel Account;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public RegistrationController(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signInManager)
        {
            //Account = _Account;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountViewModel Account) 
        {
            if (ModelState.IsValid)
            {
                // Map VM to Identityuser 
                IdentityUser user = new IdentityUser();
                user.UserName = Account.UserName;
                user.Email = Account.Email;
                // Create User 
                IdentityResult result = await userManager.CreateAsync(user, Account.Password);
               
                // Create Cookie
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("All", "Employee");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(Account);
        }
    }
}
