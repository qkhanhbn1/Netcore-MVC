﻿using System;
using System.Collections.Generic;

namespace WebAPI.Models​;

public partial class OrdersDetail
{
    public long Id { get; set; }

    public long? Idord { get; set; }

    public long? Idproduct { get; set; }

    public decimal? Price { get; set; }

    public int? Qty { get; set; }

    public decimal? Total { get; set; }

    public int? ReturnQty { get; set; }

    public virtual Order? IdordNavigation { get; set; }
}
