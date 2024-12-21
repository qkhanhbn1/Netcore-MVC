using System;
using System.Collections.Generic;

namespace DADevXuongMoc.Models​;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Avatar { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? Isdelete { get; set; }

    public bool? Isactive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
