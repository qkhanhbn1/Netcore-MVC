using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DADevXuongMoc.Models​;

public partial class Product
{
    public int Id { get; set; }

    public int? Cid { get; set; }

    public string? Code { get; set; }
    [Display(Name = "Tiêu đề")]
    public string? Title { get; set; }
    [Display(Name = "Mô tả")]
    public string? Description { get; set; }
    [Display(Name = "Nội dung")]
    public string? Content { get; set; }
    [Display(Name = "Ảnh    ")]
    public string? Image { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public string? Slug { get; set; }
    [Display(Name = "Giá cũ")]
    public decimal? PriceOld { get; set; }
    [Display(Name = "Giá mới")]
    public decimal? PriceNew { get; set; }
    [Display(Name = "Kích cỡ")]
    public string? Size { get; set; }

    public int? Views { get; set; }

    public int? Likes { get; set; }

    public double? Star { get; set; }

    public byte? Home { get; set; }

    public byte? Hot { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }
    [Display(Name = "Trạng thái")]
    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }

    public virtual Category? CidNavigation { get; set; }

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();
}
