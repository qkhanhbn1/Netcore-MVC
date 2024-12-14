using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DADevXuongMoc.Models​;

public partial class Category
{
    public int Id { get; set; }
    [Display(Name = "Tiêu đề")]
    public string? Title { get; set; }
    [Display(Name = "Ảnh")]
    public string? Icon { get; set; }

    public string? MateTitle { get; set; }
    [Display(Name = "Giới thiệu")]
    public string? MetaKeyword { get; set; }
    [Display(Name = "Mô tả")]
    public string? MetaDescription { get; set; }
    [Display(Name = "tên miền")]
    public string? Slug { get; set; }
    
    public int? Orders { get; set; }

    public int? Parentid { get; set; }
    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedDate { get; set; }
    [Display(Name = "Ngày cập nhật")]
    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }

    public string? Notes { get; set; }
    [Display(Name = "Trạng thái")]
    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
