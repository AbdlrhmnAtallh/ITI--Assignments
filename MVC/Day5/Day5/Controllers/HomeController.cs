using Day5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;

namespace Day5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
            
        }
        // Display Table
        public IActionResult AllPlayers()
        {
            var c = FCList.footballClubs;
            ViewBag.FCL= c;
            return View(Players);
        }

        // Adding Actions
        public static List<Player> Players = new List<Player>();
        public IActionResult AddPlayer()
        {
            var FC = FCList.footballClubs;
            ViewBag.Fc = FC;
            return View();
        }
        public IActionResult SaveNewPlayer(Player player)
        {
            Players.Add(new Player { Id = player.Id, Name = player.Name, FC = player.FC });
            var c = FCList.footballClubs;
            ViewBag.FCL = c;
            return View("AllPlayers", Players);
        }

        // Editing Actions 
        public IActionResult EditPlayer(int id)
        {
            var player = Players.FirstOrDefault(e => e.Id == id);
            var FC = FCList.footballClubs;
            ViewBag.FC = FC;
            return View(player);
        }
        public IActionResult SaveUpdates(Player p)
        {
            foreach (var item in Players)
            {
                if (item.Id == p.Id)
                {
                    item.Name = p.Name;
                    item.FC = p.FC;
                }
            }
            return RedirectToAction("index", Players);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //------------------------------------------

        public IActionResult Delete(int id)
        {
            Player Delter = Players.FirstOrDefault(e => e.Id == id);
            Players.Remove(Delter);
            return RedirectToAction("AllPlayers");
        }


      
            

        
        





    }
}