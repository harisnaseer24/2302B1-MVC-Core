using System.Diagnostics;

using _2302b1TempEmbedding.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _2302b1TempEmbedding.Controllers
{
    public class HomeController : Controller
    {

        [Authorize(Roles ="User")]
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

        
    }
}