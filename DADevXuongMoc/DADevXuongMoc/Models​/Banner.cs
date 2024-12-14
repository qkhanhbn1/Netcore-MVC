using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DADevXuongMoc.Models​;

public partial class Banner
{
    public int Id { get; set; }
    [Display(Name = "Ảnh")]
    public string? Image { get; set; }
    [Display(Name = "Tiêu đề")]
    public string? Title { get; set; }
    
    public string? SubTitle { get; set; }

    public string? Urls { get; set; }

    public int Orders { get; set; }

    public string? Type { get; set; }
    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }
    [Display(Name = "Mô tả")]
    public string? Notes { get; set; }
    [Display(Name = "Trạng thái")]
    public byte Status { get; set; }

    public bool Isdelete { get; set; }
}
