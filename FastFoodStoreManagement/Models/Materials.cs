using System;
using System.Collections.Generic;

namespace Models;

public partial class Materials
{
    public int MaterialId { get; set; }

    public string? Name { get; set; }

    public string? Unit { get; set; }

    public int? StockQty { get; set; }

    public int? MinThreshold { get; set; }

    public bool IsLowStock => StockQty < MinThreshold;

    public virtual ICollection<InventoryLogs> InventoryLogs { get; set; } = new List<InventoryLogs>();

    public virtual ICollection<ListItemMaterial> ListItemMaterial { get; set; } = new List<ListItemMaterial>();
}
