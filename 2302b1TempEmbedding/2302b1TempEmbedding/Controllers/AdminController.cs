using Microsoft.AspNetCore.Mvc;

namespace _2302b1TempEmbedding.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
       

            if (HttpContext.Session.GetString("role") == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            //data can be used on same view only
            //ViewBag.name = "Haris Naseer";
            //ViewData["firstName"]= "Haris";

            //data can be used on any view of same controller as well as other controllers
            //TempData["email"] = "haris@gmail.com";


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
            if (email=="admin@gmail.com" && password=="123")
            {
                HttpContext.Session.SetString("adminemail",email);
                HttpContext.Session.SetString("role","admin");


                return RedirectToAction("Index");

            }else if (email == "user@gmail.com" && password == "123")
            {
                HttpContext.Session.SetString("useremail", email);
                HttpContext.Session.SetString("role", "user");
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult AdminLogout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("adminemail");
            HttpContext.Session.Remove("role");
            return RedirectToAction("Login");
          
        }
        public IActionResult UserLogout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("useremail");
            HttpContext.Session.Remove("role");
            return RedirectToAction("Login");

        }

        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
