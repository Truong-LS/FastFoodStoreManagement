using System;
using System.Collections.Generic;

namespace Models;

public partial class Items
{
    public int ItemId { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public bool? IsAvailable { get; set; }

    public int CategoryId { get; set; }

    public virtual Categories Category { get; set; } = null!;

    public virtual ICollection<ListItemMaterial> ListItemMaterial { get; set; } = new List<ListItemMaterial>();

    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}
