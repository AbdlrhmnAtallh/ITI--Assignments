using Microsoft.AspNetCore.Mvc;
using Day9.ViewModel;

namespace Day9.Controllers
{
    public class RegistrationController : Controller
    {
        RegisterAccountViewModel Account;
        public RegistrationController(RegisterAccountViewModel _Account)
        {
            Account = _Account;
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

            }
        }
    }
}
