using System;
using System.Collections.Generic;

namespace QuickMart.API.Models;

public partial class ProductMaster
{
    public long ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public long? CategoryId { get; set; }

    public decimal? Moq { get; set; }

    public string? Brand { get; set; }

    public decimal? Price { get; set; }

    public string? ProductPhoto { get; set; }

    public string? MediaType { get; set; }

    public bool? Active { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? ModifiedBy { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual ProductCategory? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
