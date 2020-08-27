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
using Microsoft.EntityFrameworkCore;

namespace General_Quarters.Controllers
{
    public class GQController : Controller
    {
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        private GQContext db;
        public GQController(GQContext context)
        {
            db = context;
        }

        [HttpGet("main")]
        public IActionResult Main()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Game> allGames = db.Games
            .Include(g => g.Creator)
            .Include(g => g.JoinGames)
            .ThenInclude(g => g.Joiner)
            .OrderByDescending(g => g.CreatedAt)
            .ToList();

            return View("Main", allGames);
        }


        [HttpPost("CreateGame")]
        public IActionResult CreateGame(Game newGame)
        {
            if (uid == null){
                return RedirectToAction("Index", "Home");
            }
            newGame.UserId = (int)uid;
            db.Add(newGame);
            db.SaveChanges();

            return RedirectToAction("DashBoard", "Game", new { gameId = newGame.GameId });
        }

        [HttpGet("JoinGame")]
        public IActionResult JoinGame(JoinGame newJoin)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            JoinGame alreadyJoined = db.JoinedGames
            .Include(game => game.GameToJoin)
            .ThenInclude(game => game.Creator)
            .FirstOrDefault(j => j.GameId == newJoin.GameId);
            
            if (alreadyJoined == null)
            {
                newJoin.UserId = (int)uid;
                db.JoinedGames.Add(newJoin);
                db.SaveChanges();
                return RedirectToAction("DashBoard", "Game", new { gameId = newJoin.GameId} ); 
            }
            return RedirectToAction("Main");
        }

        [HttpGet("EnterGame")]
        public IActionResult EnterGame(int gameId)
        {
            return RedirectToAction("DashBoard", "Game", new { gameId = gameId} );
        }
        
        [HttpGet("DeleteGame")]
        public IActionResult DeleteGame(int gameId)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Game thisGame = db.Games
            .Include(game => game.Creator)
            .FirstOrDefault(game => game.GameId == gameId && game.Creator.UserId == uid);

            db.Games.Remove(thisGame);
            db.SaveChanges();
            return RedirectToAction("Main");
        }
    }
}
