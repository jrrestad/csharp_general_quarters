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

        [HttpGet("dashboard")]
        public IActionResult DashBoard()
        {
           if (uid == null)
           {
               return RedirectToAction("Index", "Home");
           }
           return View("Dashboard", "GQ");
        }
    }
}
