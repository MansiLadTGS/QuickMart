using System;
using System.Collections.Generic;

namespace QuickMart.API.Models;

public partial class CustomerPaymentProfile
{
    public long ProfileId { get; set; }

    public long CustomerId { get; set; }

    public string? PgatewayCustomerId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
