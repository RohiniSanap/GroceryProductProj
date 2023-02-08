using GroceryProductProj.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace GroceryProductProj.Controllers
{
    public class SaleController : Controller
    {
        private readonly ProductDataContext _db;

        public object JsonRequestBehaviour { get; private set; }

        public SaleController(ProductDataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult sale()
        {
            SalePage salePage = new SalePage();
            ProductDataContext productDataContext = new ProductDataContext();
            ViewBag.Product = new SelectList(productDataContext.GroceryProducts.ToList(), "ProductId", "ProductName");
            return View(salePage);
        }
        [HttpPost]
        public IActionResult sale(SalePage salePage)
        {
            ProductDataContext productDataContext = new ProductDataContext();
            productDataContext.Add(salePage);
            productDataContext.SaveChanges();
            ViewBag.Message = "Product recept generated";

            ViewBag.Product = new SelectList(productDataContext.GroceryProducts.ToList(), "ProductId", "ProductName");

            //var data = from als in _db.GroceryProducts select new { als.ProductName, als.ProductPrice };
            //return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            return View(salePage);
        }

        [HttpGet]
        public IActionResult GetRate(int ProductId)
        {
            var productPrice = _db.GroceryProducts.Where(x => x.ProductId == ProductId).Select(x => x.ProductPrice).FirstOrDefault();
            return Json(productPrice);
        }
        
    
}
}
