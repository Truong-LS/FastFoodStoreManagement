using System;
using System.Collections.Generic;

namespace Models;

public partial class ListItemMaterial
{
    public int ItemId { get; set; }

    public int MaterialId { get; set; }

    public int? QuantityUsed { get; set; }

    public virtual Items Item { get; set; } = null!;

    public virtual Materials Material { get; set; } = null!;
}
