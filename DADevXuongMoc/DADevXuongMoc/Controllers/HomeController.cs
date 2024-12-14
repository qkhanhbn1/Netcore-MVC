using DADevXuongMoc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;

namespace DADevXuongMoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly DevXuongMocContext _context;

        public HomeController(DevXuongMocContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Home/Login
        [HttpPost]
        public async Task<IActionResult> Login(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Tìm kiếm tài khoản trong cơ sở dữ liệu
            var customer = _context.Customers
                .FirstOrDefault(c => c.Email == model.Email);

            if (customer == null || !BCrypt.Net.BCrypt.Verify(model.Password, customer.Password))
            {
                ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không chính xác.");
                return View(model);
            }

            // Lưu thông tin người dùng vào ClaimsIdentity
            var identity = new ClaimsIdentity(new[]
            {
        new Claim(ClaimTypes.Name, customer.Name),
        new Claim(ClaimTypes.Email, customer.Email),
        new Claim("CustomerId", customer.Id.ToString()) // Lưu thêm ID khách hàng
    }, "DevSecuritySchema");

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("DevSecuritySchema", principal);

            // Lưu thông tin khách hàng vào session
            HttpContext.Session.SetString("Member", JsonConvert.SerializeObject(customer));

            // Chuyển hướng về trang gốc hoặc trang trước đó (nếu có)
            string returnUrl = HttpContext.Request.Query["ReturnUrl"];
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }






        // GET: /Home/Register
        public IActionResult Register()
        {
            return View();
        }
        // POST: /Home/Register
        [HttpPost]
        public IActionResult Register(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kiểm tra xem email đã tồn tại chưa
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.Email == model.Email);
            if (existingCustomer != null)
            {
                ModelState.AddModelError("Email", "Email này đã được đăng ký.");
                return View(model);
            }

            // Hash mật khẩu trước khi lưu
            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            // Thêm các giá trị mặc định khác
            model.CreatedDate = DateTime.Now;
            //model.Isactive =  // 1: Active, 0: Inactive

            // Lưu vào cơ sở dữ liệu
            _context.Customers.Add(model);
            _context.SaveChanges();

            // Chuyển hướng sang trang đăng nhập
            return RedirectToAction("Login", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            // Đăng xuất khỏi schema "DevSecuritySchema"
            await HttpContext.SignOutAsync("DevSecuritySchema");

            // Chuyển hướng về trang Login
            return RedirectToAction("Login", "Home");
        }
    }
}
