using System;
using System.Collections.Generic;

namespace Models;

public partial class Discounts
{
    public int DiscountId { get; set; }

    public string? Code { get; set; }

    public int? Type { get; set; }

    public double? Value { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
