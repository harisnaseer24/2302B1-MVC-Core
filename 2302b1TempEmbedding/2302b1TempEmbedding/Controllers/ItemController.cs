using _2302b1TempEmbedding.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2302b1TempEmbedding.Controllers
{
    public class ItemController : Controller
    {
        //_2302b1dotnetContext db = new _2302b1dotnetContext();

        private readonly _2302b1dotnetContext db;
        public ItemController(_2302b1dotnetContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            var itemdata = db.Items.Include(it => it.Cat);
            return View(itemdata.ToList());
        }
    }
}
