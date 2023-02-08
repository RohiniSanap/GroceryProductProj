using GroceryProductProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroceryProductProj.Controllers
{
    public class EditController : Controller
    {
        private readonly ProductDataContext _db;
        public EditController(ProductDataContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            List<GroceryProduct> products = _db.GroceryProducts.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GroceryProduct groceryProduct)
        {
            if (ModelState.IsValid)
            {
                _db.GroceryProducts.Add(groceryProduct);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groceryProduct);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            GroceryProduct groceryProduct = _db.GroceryProducts.Single(x => x.ProductId == id);
            return View(groceryProduct);
        }
        [HttpPost]

        public IActionResult Edit(GroceryProduct groceryProduct)
        {
            if (ModelState.IsValid)
            {

                _db.Entry(groceryProduct).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groceryProduct);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            GroceryProduct groceryProduct = _db.GroceryProducts.Single(x => x.ProductId == id);
            return View(groceryProduct);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleteconfirm(int id)
        {
            GroceryProduct groceryProduct = _db.GroceryProducts.Single(x => x.ProductId == id);
            _db.GroceryProducts.Remove(groceryProduct);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            GroceryProduct groceryProduct = new GroceryProduct();
            groceryProduct = _db.GroceryProducts.Single(x => x.ProductId == id);
            return View(groceryProduct);
        }

    }
}
