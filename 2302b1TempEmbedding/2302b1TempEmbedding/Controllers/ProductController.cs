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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product prd)
        {
            if (ModelState.IsValid) { 
            
                db.Products.Add(prd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

            return View();
            }
        }



    }
}
