using System;
using System.Collections.Generic;

namespace QuickMart.Core.Models;

public partial class ProductCategory
{
    public long ProductCategoryId { get; set; }

    public string? Name { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<ProductMaster> ProductMasters { get; set; } = new List<ProductMaster>();
}
