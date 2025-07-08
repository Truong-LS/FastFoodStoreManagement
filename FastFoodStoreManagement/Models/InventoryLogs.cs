using System;
using System.Collections.Generic;

namespace Models;

public partial class InventoryLogs
{
    public int LogId { get; set; }

    public string? LogType { get; set; }

    public int? ChangeQty { get; set; }

    public string? Unit { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UserId { get; set; }

    public int? MaterialId { get; set; }

    public int? SupplierId { get; set; }

    public virtual Materials? Material { get; set; }

    public virtual Suppliers? Supplier { get; set; }

    public virtual Users? User { get; set; }
}
