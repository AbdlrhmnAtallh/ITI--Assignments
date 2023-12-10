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
               
                if (result.Succeeded)
                {
                    // Create Cookie
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

        [HttpGet]
        public IActionResult Login([FromQuery]string ReturnUrl = "~/Employee/All")
        {
            ViewBag.Url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel LoginUser )
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(LoginUser.Username);
                if (user!=null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result
                        = await signInManager.PasswordSignInAsync(user, LoginUser.Password, LoginUser.Ispersisite, false);
                    if (result.Succeeded)
                    {
                        // return RedirectToAction("Auth", "Employee");
                        return Redirect(ViewBag.Url);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Username or Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect Username or Password");
                }
            }
                return View(LoginUser);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
