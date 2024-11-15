using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace NetcoreLab5.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [
            Display(Name = "Họ và tên"),
            Required(ErrorMessage ="Họ không được để trống"),
            MinLength(6,ErrorMessage ="Họ tên ít nhất 6 kí tự"),
            MaxLength(20,ErrorMessage ="Họ tên không quá 20 kí tự")
        ]
        public string FullName { get; set; }
            [Display(Name = "Địa chỉ email")]
            [Required(ErrorMessage = "Email không được để trống")]
            [EmailAddress(ErrorMessage ="Địa chỉ email không đúng định dạng")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"abc",ErrorMessage = "Số điện thoại không đúng định dạng")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Facebook")]
        public string Facebook { get; set; }
    }
}
