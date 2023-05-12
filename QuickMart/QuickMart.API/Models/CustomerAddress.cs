using System;
using System.Collections.Generic;

namespace QuickMart.API.Models;

public partial class CustomerAddress
{
    public long AddressId { get; set; }

    public long? CustomerId { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Country { get; set; }

    public string? State { get; set; }

    public string? City { get; set; }

    public string? ZipCode { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
