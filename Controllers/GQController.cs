using General_Quarters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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