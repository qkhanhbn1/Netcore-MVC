using Lab09.Areas.Admins.Models;
using Lab09.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Resources;
using System.Security.AccessControl;

namespace Lab09.Controllers
{
    public class CustomerMemberController : Controller
    {
        public readonly DevXuongMocContext _context;
        public CustomerMemberController(DevXuongMocContext context)
        {
            _context = context;
        }
        public IActionResult Index(string url)
        {
            if(HttpContext.Session.GetString("Member") != null)
            {
                var dataLogin = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("Member"));
                ViewBag.Customer = dataLogin;
            }
            ViewBag.UrlAction = url;
            return View();
        }
        [HttpPost]
        public IActionResult Registy(Customer model)
        {
            try
            {
                // Kiểm tra tính hợp lệ của model
                if (!ModelState.IsValid)
                {
                    TempData["errorRegisty"] = "Dữ liệu đầu vào không hợp lệ.";
                    return View(model);  // Quay lại view với thông báo lỗi
                }

                // Kiểm tra trùng lặp email hoặc username
                if (_context.Customers.Any(c => c.Email == model.Email || c.Username == model.Username))
                {
                    TempData["errorRegisty"] = "Email hoặc Tên đăng nhập đã tồn tại.";
                    return View(model);  // Quay lại view với thông báo lỗi
                }

                // Tiến hành mã hóa mật khẩu
                var pass = Utilities.Utils.GetSHA26Hash(model.Password);
                model.Password = pass;

                // Thiết lập các giá trị khác
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                model.Isactive = 1;

                // Lưu thông tin vào cơ sở dữ liệu
                _context.Add(model);
                int result = _context.SaveChanges();  // Kiểm tra kết quả trả về
                if (result > 0)
                {
                    TempData["successRegisty"] = "Đăng ký thành công!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorRegisty"] = "Đã xảy ra lỗi trong quá trình lưu dữ liệu.";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                TempData["errorRegisty"] = "Lỗi đăng ký: " + ex.Message;
                return View(model);  // Quay lại view với thông báo lỗi
            }
        }

        [HttpPost]

        public IActionResult Login(Customer model, string urlAction)
        {
            try
            {
                // Mã hóa mật khẩu bằng SHA256
                var hashedPassword = Utilities.Utils.GetSHA26Hash(model.Password);

                // Tìm khách hàng với điều kiện IsActive = 1 và thông tin đăng nhập đúng
                var user = _context.Customers
                    .Where(x => x.Isactive == 1)
                    .FirstOrDefault(x =>
                        (x.Username.Equals(model.Email) || x.Email.Equals(model.Email)) &&
                        x.Password.Equals(hashedPassword)
                    );

                // Kiểm tra thông tin đăng nhập
                if (user != null)
                {
                    // Chuyển đổi dữ liệu user sang JSON để lưu session
                    var dataLogin = user.ToJson();

                    // Lưu thông tin đăng nhập vào session
                    HttpContext.Session.SetString("Member", dataLogin);

                    // Chuyển hướng đến URL được cung cấp, nếu có
                    if (!string.IsNullOrEmpty(urlAction))
                    {
                        return Redirect(urlAction);
                    }

                    // Mặc định chuyển hướng đến trang Index
                    return RedirectToAction("Index");
                }

                // Thông báo lỗi khi đăng nhập thất bại
                TempData["errorLogin"] = "Lỗi đăng nhập: Sai tên đăng nhập hoặc mật khẩu.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và ghi log
                TempData["errorLogin"] = $"Lỗi đăng nhập: {ex.Message}";
                Console.WriteLine(ex.StackTrace); // Ghi log ra console (hoặc sử dụng hệ thống logging)
                return RedirectToAction("Index");
            }
        }

    }
}
