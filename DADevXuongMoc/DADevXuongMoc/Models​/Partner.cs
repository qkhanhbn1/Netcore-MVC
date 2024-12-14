using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DADevXuongMoc.Models​;

public partial class Partner
{
    public int Id { get; set; }
    [Display(Name = "Tiêu đề")]
    public string? Title { get; set; }

    public string? Logo { get; set; }

    public string? Url { get; set; }

    public byte? Orders { get; set; }
    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }
    [Display(Name = "Nội dung")]
    public string? Content { get; set; }
    [Display(Name = "Trạng thái")]
    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }
}
