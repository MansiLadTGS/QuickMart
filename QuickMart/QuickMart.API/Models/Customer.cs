using System;
using System.Collections.Generic;

namespace QuickMart.API.Models;

public partial class Customer
{
    public long CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public decimal? Phone { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public bool? Active { get; set; }

    public bool? Deleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    public virtual ICollection<CustomerPaymentProfile> CustomerPaymentProfiles { get; set; } = new List<CustomerPaymentProfile>();

    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
