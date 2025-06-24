using System;
using System.Collections.Generic;

namespace Models;

public partial class Roles
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
