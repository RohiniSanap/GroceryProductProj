using GroceryProductProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryProductProj.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]

        public IActionResult Login()

        {

            LoginPage loginpage = new LoginPage();

            return View(loginpage);

        }

        [HttpPost]

        public IActionResult Login(LoginPage loginpage)

        {

            ProductDataContext productDataContext = new ProductDataContext();

            var status = productDataContext.LoginPages.Where(m => m.UserName == loginpage.UserName && m.Pasword == loginpage.Pasword).FirstOrDefault();

            if (status != null)

            {

                ViewBag.Message = "Success full login";


                HttpContext.Session.SetString("UserName",loginpage.UserName);

                return RedirectToAction("Index", "Edit");

            }


            else

            {

                ViewBag.Message = "Invalid login detail.";

            }

            return View(loginpage);

        }
        [HttpPost]
        public IActionResult logout()
        {
            return RedirectToAction("Product", "Product");
            //return View(login);
        }
    }
}


