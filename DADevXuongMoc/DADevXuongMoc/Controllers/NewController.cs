using DADevXuongMoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DADevXuongMoc.Controllers
{
    public class NewController : Controller
    {
        private readonly DevXuongMocContext _context;
        public NewController(DevXuongMocContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.News.DefaultIfEmpty().ToListAsync();

            return View(data);
        }
    }
}