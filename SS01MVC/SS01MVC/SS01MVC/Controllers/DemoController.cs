using Microsoft.AspNetCore.Mvc;

namespace SS01MVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
