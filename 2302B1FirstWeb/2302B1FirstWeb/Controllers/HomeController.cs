using _2302B1FirstWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2302B1FirstWeb.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        
    }
}