using System;
using System.Collections.Generic;

namespace QuickMart.Core.Models;

public partial class OrderMaster
{
    public long OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public long? CustomerId { get; set; }

    public long? AddressId { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? DiscountValue { get; set; }

    public decimal? NetValue { get; set; }

    public string? OrderStatus { get; set; }

    public DateTime? ShippedDate { get; set; }

    public DateTime? DeliveredDate { get; set; }

    public string? PaymentMode { get; set; }

    public long? PaymentProfileId { get; set; }

    public string? PgatewayTxnId { get; set; }

    public string? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual CustomerAddress? Address { get; set; }

    public virtual Customer? Customer { get; set; }
}
