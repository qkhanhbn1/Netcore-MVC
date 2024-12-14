using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DADevXuongMoc.Models​;

public partial class Contact
{
    public int Id { get; set; }
    [Display(Name = "Tiêu đề")]
    public string? Title { get; set; }

    public string? Email { get; set; }
    [Display(Name = "Số điện thoại")]
    public string? Phone { get; set; }
    [Display(Name = "Địa chỉ")]
    public string? Address { get; set; }
    [Display(Name = "Nội dung")]
    public string? Content { get; set; }
    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }

    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }
}
