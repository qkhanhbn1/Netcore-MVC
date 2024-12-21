using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DADevXuongMoc.Models; // Đảm bảo đúng namespace

namespace DADevXuongMoc.Controllers
{
    public class ContactController : Controller
    {
        private readonly DevXuongMocContext _context;

        public ContactController(DevXuongMocContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        //home email
        [HttpPost]
        public async Task<IActionResult> SaveEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return Json(new { success = false, message = "Email không được để trống." });
            }

            try
            {
                // Tạo đối tượng Contact mới
                var contact = new Contact
                {
                    Email = email,
                    CreatedDate = DateTime.Now,
                    Status = 1, // Giá trị tuỳ ý
                    Isdelete = false
                };

                // Lưu vào cơ sở dữ liệu
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Thành công" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Có lỗi xảy ra: {ex.Message}" });
            }
        }

        //contact action index
        [HttpPost]
        public async Task<IActionResult> SaveContact(string username, string email, string phone, string description)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                return Json(new { success = false, message = "Vui lòng điền đầy đủ thông tin bắt buộc." });
            }

            try
            {
                // Tạo đối tượng Contact mới
                var contact = new Contact
                {
                    Title = username,
                    Email = email,
                    Phone = phone,
                    Content = description,
                    CreatedDate = DateTime.Now,
                    Status = 1, // Hoặc giá trị logic của bạn
                    Isdelete = false
                };

                // Lưu vào cơ sở dữ liệu
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Thành công! chúng tôi sẽ liên hệ với bạn trong sớm nhất có thể" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Có lỗi xảy ra: {ex.Message}" });
            }
        }
    }
}
    
