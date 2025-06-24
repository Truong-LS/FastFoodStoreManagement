using System;
using System.Collections.Generic;

namespace Models;

public partial class Suppliers
{
    public int SupplierId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTime? LatedUpdate { get; set; }

    public virtual ICollection<InventoryLogs> InventoryLogs { get; set; } = new List<InventoryLogs>();
}
