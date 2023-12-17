using Microsoft.AspNetCore.Mvc;
using Day9.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;

namespace Day9.Controllers
{
    public class RegistrationController : Controller
    {
        //RegisterAccountViewModel Account;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public RegistrationController(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signInManager,RoleManager<IdentityRole> _roleManager)
        {
            //Account = _Account;
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
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
        public IActionResult Login() 
        { 
            //ViewBag.Url = ReturnUrl;
            return View();
        }

        [HttpPost]
        [Route("Registration/Login", Name = "RegistrationLogin")]
        public async Task<IActionResult> Login(LoginViewModel LoginUser , string returnUrl )
        {
            ModelState.Remove(returnUrl);
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(LoginUser.Username);
                if (user!=null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result
                        = await signInManager.PasswordSignInAsync(user, LoginUser.Password, LoginUser.Ispersisite, false);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)) // Url.IsLocalIrl checks if the returnUrl is a local URL within the same application
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Auth", "Employee");
                        //return Redirect(ViewBag.Url);
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
        [Authorize(Roles ="Admin")]
        public IActionResult AddAdmin()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterAccountViewModel Account)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = Account.UserName,
                    Email = Account.Email,
                };
                IdentityResult result = await userManager.CreateAsync(user, Account.Password);

                var role = roleManager.Roles.FirstOrDefault(e => e.Name == "Admin");
                if (result.Succeeded && role!=null)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
                return View("Register",Account);
        }





    }
}
