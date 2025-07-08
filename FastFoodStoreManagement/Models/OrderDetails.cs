using System;
using System.Collections.Generic;

namespace Models;

public partial class OrderDetails
{
    public int DetailId { get; set; }

    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public int? Quantity { get; set; }

    public double? UnitPrice { get; set; }

    public virtual Items Item { get; set; } = null!;

    public virtual Orders Order { get; set; } = null!;
}
