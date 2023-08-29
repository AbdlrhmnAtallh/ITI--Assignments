using Microsoft.AspNetCore.Mvc;
using Day4.Models;
namespace Day4.Controllers
{
    public class PlayersController : Controller
    {
        AppdbContext Context = new AppdbContext();
        public IActionResult AllPlayers()
        {
            ViewData["FCBag"] = Context.FootballClub.ToList();
            var model = Context.Player.ToList();
            return View(model);
        }
        public IActionResult AddPlayer()
        {
            //ViewBag.FC = Context.FootballClub.ToList();
            List<FootballClub> fc = Context.FootballClub.ToList();
            ViewData["FC"] = fc;
            return View();
        }
        public IActionResult SaveNewPlayer(Player player)
        {
            Context.Add(player);
            Context.SaveChanges();
            return RedirectToAction("AllPlayers");
        }
        public IActionResult EditPlayer(int id)
        {
            ViewBag.FC = Context.FootballClub.ToList();
            var player = Context.Player.FirstOrDefault(e => e.Id == id);
            return View(player);
        }
        
        public IActionResult SaveUpdates(int id ,Player NewPlayer)
        {
            Player player = Context.Player.FirstOrDefault(p => p.Id == id);
            player.Name = NewPlayer.Name;
            player.Age = NewPlayer.Age;
            player.FC = NewPlayer.FC;
            Context.SaveChanges();
            return RedirectToAction("AllPlayers");
        }
        public IActionResult AddFC()
        {
            return View();
        }
        public IActionResult SaveFC(FootballClub fc)
        {
            Context.Add(fc);
            Context.SaveChanges();
            return RedirectToAction("AllPlayers");
        }

    }
}
