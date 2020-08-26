using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using General_Quarters.Models;

namespace General_Quarters.Controllers
{
    public class GameController : Controller
    {
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        private GQContext db;
        public GameController(GQContext context)
        {
            db = context;
        }
        
        [HttpGet("/main/dashboard/{gameId}")]
        public IActionResult DashBoard(int gameId)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Game thisGame = db.Games
            .FirstOrDefault(game => game.GameId == gameId);

            return View("Dashboard", thisGame);
        }
    }
}
