using Microsoft.AspNetCore.Mvc;

namespace _2302b1TempEmbedding.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {

            //data can be used on same view only
            ViewBag.name = "Haris Naseer";
            ViewData["firstName"]= "Haris";

            //data can be used on any view of same controller as well as other controllers
            TempData["email"] = "haris@gmail.com";

            return View();
        }

        public IActionResult Privacy()
        {
            TempData.Keep("email");

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {

            if (email=="haris@gmail.com" && password=="123")
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View();

            }
         
        }
    }
}
