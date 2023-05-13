using System;
using System.Collections.Generic;

namespace QuickMart.Core.Models;

public partial class CartDetail
{
    public long CartId { get; set; }

    public long? ProductId { get; set; }

    public long? CustomerId { get; set; }

    public bool? IsDelivered { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ProductMasterOLD? Product { get; set; }
}
