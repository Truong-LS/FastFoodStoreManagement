using System;
using System.Collections.Generic;

namespace Models;

public partial class Payments
{
    public int PaymentId { get; set; }

    public int? Amount { get; set; }

    public string? Method { get; set; }

    public DateTime? PaidAt { get; set; }

    public int? OrderId { get; set; }

    public virtual Orders? Order { get; set; }
}
