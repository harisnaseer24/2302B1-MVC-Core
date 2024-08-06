using System.Diagnostics;

using _2302b1TempEmbedding.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2302b1TempEmbedding.Controllers
{
    public class HomeController : Controller
    {
        private readonly _2302b1dotnetContext db;
        public HomeController(_2302b1dotnetContext _db)
        {
            db = _db;
        }


        //[Authorize(Roles ="User")]
        public IActionResult Index()
        {
           
            //if (HttpContext.Session.GetString("role") == "user")
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login","Admin");
            //}
            //TempData.Keep("email");
            //return View();
            return View();
        }
        [Authorize]
        public IActionResult About()
        {
            return View("AboutUs");
        }

        public IActionResult Products()
        {
            var itemdata = db.Items.Include(it => it.Cat);
            return View(itemdata.ToList());
        }
        
    }
}