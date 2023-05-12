using System;
using System.Collections.Generic;

namespace QuickMart.API.Models;

public partial class OrderItem
{
    public long OrderId { get; set; }

    public long? ProductId { get; set; }

    public int? Qty { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public decimal? OrderAmount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ProductMaster? Product { get; set; }
}
