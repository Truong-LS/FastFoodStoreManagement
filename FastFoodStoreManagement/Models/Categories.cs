using System;
using System.Collections.Generic;

namespace Models;

public partial class Categories
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Items> Items { get; set; } = new List<Items>();
}
