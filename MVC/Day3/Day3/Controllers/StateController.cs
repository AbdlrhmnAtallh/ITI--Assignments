using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Set()
        {
            TempData["name"] = "XYZ";
            return Content("Data Saved");
        }
        public IActionResult get1()
        {
            if (TempData.ContainsKey("name"))
            {
                string name = TempData["name"].ToString();
                TempData.Keep("name");
                return Content($"Temp data = {name}");
            }
            return Content("null");
            
        }
        public IActionResult get2()
        {
            if (TempData.ContainsKey("name"))
            {
                string name = TempData["name"].ToString();
                return Content($"Temp data ={name}");
            }
            return Content("null");
        }

        public IActionResult setSession()
        {
            string Name = "XYZ";
            int Age = 20;
            HttpContext.Session.SetString("Name", Name);
            HttpContext.Session.SetInt32("Age", Age);
            return Content("DataSaved");
        }
        public IActionResult GetSession()
        {
            string Name = HttpContext.Session.GetString("Name");
            int? Age = HttpContext.Session.GetInt32("Age");
            return Content($"Name {Name} Age {Age}");
        }

        public IActionResult SetCookies()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(1);
            Response.Cookies.Append("Username", "USER1",cookieOptions);
            Response.Cookies.Append("Password", "123", cookieOptions);
            Response.Cookies.Append("FavSong", "Hello");
            return Content("Cookies Saved");
        }
        public IActionResult GetCookies()
        {
            //List<string> Cookies = new List<string>();
            //Cookies.Add(Request.Cookies["Username"].ToString());
            //Cookies.Add(Request.Cookies["Password"].ToString());
            //Cookies.Add(Request.Cookies["FavSong"].ToString());
            string username = Request.Cookies["Username"].ToString();
            string password = Request.Cookies["Password"].ToString();
            if (Request.Cookies.ContainsKey("FavSong"))
            {
            string favSong = Request.Cookies["FavSong"].ToString();
            return Content($"username {username} .. Password {password} .. FavSong {favSong}");
            }
            return Content($"username {username} .. Password {password} .. No Cookies For FavSong");

        }


    }
}
