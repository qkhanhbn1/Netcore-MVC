using Microsoft.AspNetCore.Mvc;
using SS02.Models;

namespace SS02.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllProduct()
        {
            
            return View("Products");  
        }
        public IActionResult GetProducts()
        {
            Product p = new Product
            {
                ProductId = 1,
                ProductName = "Test",
                YearRelease = 2024,
                Price=3.144,
                
            };
            ViewBag.product = p;
            ViewData["ProductVD"] = p;
            return View();
        }
    }
}
