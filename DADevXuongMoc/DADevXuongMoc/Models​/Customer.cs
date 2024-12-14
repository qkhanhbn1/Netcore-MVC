using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DADevXuongMoc.Models​;

public partial class Customer
{
    public int Id { get; set; }
    [Display(Name = "Tên")]
    public string? Name { get; set; }
    [Display(Name = "Tên tài khoản")]
    public string? Username { get; set; }
    [Display(Name = "Mật khẩu")]
    public string? Password { get; set; }
    [Display(Name = "Địa chỉ")]
    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Avatar { get; set; }
    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? Isdelete { get; set; }

    public bool? Isactive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
