﻿using System;
using System.Collections.Generic;

namespace QuickMart.API.Models;

public partial class ProductCategory
{
    public long ProductCategoryId { get; set; }

    public string? Name { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<ProductMasterOLD> ProductMasters { get; set; } = new List<ProductMasterOLD>();
}
