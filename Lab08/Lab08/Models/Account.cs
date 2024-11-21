using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab08.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Họ và tên")]
        [Required(ErrorMessage ="Họ không được để trống")]
        [MinLength(6,ErrorMessage ="ít nhất 6 kí tự")]
        [MaxLength(20,ErrorMessage ="tối đa 20 kí tự")]
        public string Name { get; set; }
        [Display(Name ="email")]
        [Required(ErrorMessage = "email không được để trống")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name ="Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name ="Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
