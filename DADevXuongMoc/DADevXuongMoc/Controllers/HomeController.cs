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

        //profile customer
        public async Task<IActionResult> Profile()
        {
            // Lấy thông tin ID khách hàng từ Claims
            var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CustomerId");
            if (customerIdClaim == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int customerId = int.Parse(customerIdClaim.Value);

            // Lấy thông tin khách hàng từ cơ sở dữ liệu
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        [HttpPost]
        public IActionResult UpdateProfile(Customer model)
        {
            if (ModelState.IsValid)
            {
                // Tìm khách hàng từ cơ sở dữ liệu
                var customer = _context.Customers.FirstOrDefault(c => c.Id == model.Id);

                if (customer != null)
                {
                    // Cập nhật các thông tin
                    customer.Name = model.Name;
                    customer.Email = model.Email;
                    customer.Username = model.Username;
                    customer.Address = model.Address;
                    customer.Phone = model.Phone;

                    // Lưu vào cơ sở dữ liệu
                    _context.SaveChanges();
                }

                // Sau khi cập nhật, chuyển hướng về trang Profile
                return RedirectToAction("Profile");
            }

            // Nếu có lỗi, quay lại trang Profile với thông tin đã sửa
            return View(model);
        }



        public IActionResult Orders()
        {
            var customerIdClaim = User?.FindFirst("CustomerId")?.Value;
            if (string.IsNullOrEmpty(customerIdClaim))
            {
                return RedirectToAction("Login", "Home");  // Nếu không có customerId, yêu cầu đăng nhập lại.
            }

            // Lấy customerId từ Claims
            int customerId = int.Parse(customerIdClaim);

            // Truy vấn các đơn hàng của khách hàng từ cơ sở dữ liệu
            var orders = _context.Orders.Where(o => o.Idcustomer == customerId).ToList();

            // Trả về View với danh sách đơn hàng
            return View(orders);
        }


        public async Task<IActionResult> OrderDetails(long id)
        {
            // Lấy danh sách OrdersDetail của đơn hàng
            var orderDetails = await _context.OrdersDetails
                .Include(od => od.IdproductNavigation) // Bao gồm thông tin sản phẩm
                .Where(od => od.Idord == id) // Lọc theo Id của đơn hàng
                .ToListAsync();

            if (!orderDetails.Any())
            {
                return NotFound("Không tìm thấy chi tiết đơn hàng.");
            }

            return View(orderDetails);
        }
    }
}
