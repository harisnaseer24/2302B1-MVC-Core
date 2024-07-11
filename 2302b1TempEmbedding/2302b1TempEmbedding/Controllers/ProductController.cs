using _2302b1TempEmbedding.Models;

using Microsoft.AspNetCore.Mvc;

namespace _2302b1TempEmbedding.Controllers
{
    public class ProductController : Controller
    {
        _2302b1dotnetContext db = new _2302b1dotnetContext();
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}
