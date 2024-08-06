using System.Security.Claims;

using _2302b1TempEmbedding.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _2302b1TempEmbedding.Controllers
{
    public class AuthController : Controller
    {
        private readonly _2302b1dotnetContext db;

        public AuthController(_2302b1dotnetContext _db)
        {
            db = _db;
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            var checkUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
            if (checkUser ==null)
            {
                var hasher = new PasswordHasher<string>();
                var hashPassword = hasher.HashPassword(user.Email, user.Password);
                user.Password = hashPassword;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.msg = "User already registered. Please login.";
                return View();
            }

            
        }


        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
  
        public IActionResult Login(string email, string password)
        {
            bool IsAuthenticated = false;
            bool IsAdmin = false;
            ClaimsIdentity identity = null;

            if (email == "admin@gmail.com" && password == "123")
            {
                identity = new ClaimsIdentity(new[]
                 {
                    new Claim(ClaimTypes.Name ,"Haris"),
                    new Claim(ClaimTypes.Role ,"Admin"),
                    
                }
                , CookieAuthenticationDefaults.AuthenticationScheme);
                IsAuthenticated = true;
                IsAdmin = true;
            }
            else if (email == "user@gmail.com" && password == "123")
            {
                identity = new ClaimsIdentity(new[]
                  {
                    new Claim(ClaimTypes.Name ,"User1"),
                    new Claim(ClaimTypes.Role ,"USer"),

                }
                 , CookieAuthenticationDefaults.AuthenticationScheme);
                IsAuthenticated = true;
                IsAdmin = false;
              
            }
           
            if(IsAuthenticated && IsAdmin)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Admin");
            }
            else if (IsAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();

            }
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

    }
}
