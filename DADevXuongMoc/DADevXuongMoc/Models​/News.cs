using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DADevXuongMoc.Models​;

public partial class News
{
    public int Id { get; set; }

    public string? Code { get; set; }
    [Display(Name = "Tiêu đề")]
    public string? Title { get; set; }
    [Display(Name = "mô tả")]
    public string? Description { get; set; }
    [Display(Name = "nội dung")]
    public string? Content { get; set; }
    [Display(Name = "Ảnh")]
    public string? Image { get; set; }

    public string? MetaTitle { get; set; }

    public string? MainKeyword { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public string? Slug { get; set; }

    public int? Views { get; set; }

    public int? Likes { get; set; }

    public double? Star { get; set; }
    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }
    [Display(Name = "Trạng thái")]
    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }
}
