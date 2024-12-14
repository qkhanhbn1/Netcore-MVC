using System.ComponentModel.DataAnnotations;

namespace DADevXuongMoc.Areas.Admins.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Địa chỉ email không được để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
