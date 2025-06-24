using System;
using System.Collections.Generic;

namespace Models;

public partial class Orders
{
    public int OrderId { get; set; }

    public DateTime? OrderTime { get; set; }

    public double? TotalAmount { get; set; }

    public bool? Status { get; set; }

    public string? OrderType { get; set; }

    public int UserId { get; set; }

    public int? DiscountId { get; set; }

    public virtual Discounts? Discount { get; set; }

    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    public virtual ICollection<Payments> Payments { get; set; } = new List<Payments>();

    public virtual Users User { get; set; } = null!;
}
