﻿using System;
using System.Collections.Generic;

namespace DADevXuongMoc.Models​;

public partial class Order
{
    public long Id { get; set; }

    public string? Idorders { get; set; }

    public DateTime? OrdersDate { get; set; }

    public int? Idcustomer { get; set; }

    public long? Idpayment { get; set; }

    public decimal? TotalMoney { get; set; }

    public string? Notes { get; set; }

    public string? NameReciver { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public byte? Isdelete { get; set; }

    public byte? Isactive { get; set; }

    public virtual Customer? IdcustomerNavigation { get; set; }

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();
}
