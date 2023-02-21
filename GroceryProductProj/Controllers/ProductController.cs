using GroceryProductProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryProductProj.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductDataContext _db;
        public ProductController(ProductDataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Product()
        {
            var Getrecords = _db.GroceryProducts.ToList();
            List<GroceryProduct> products = new List<GroceryProduct>();
            foreach (var item in Getrecords)
            {
                var productClass = new GroceryProduct()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductPrice = item.ProductPrice,
                    ProductQuantity = item.ProductQuantity,
                };
                products.Add(productClass);

            };
            return View(products);
        }


    }

}

