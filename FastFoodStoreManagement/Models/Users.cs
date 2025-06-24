using System;
using System.Collections.Generic;

namespace Models;

public partial class Users
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public bool? IsActive { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<InventoryLogs> InventoryLogs { get; set; } = new List<InventoryLogs>();

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();

    public virtual Roles Role { get; set; } = null!;

    public virtual ICollection<UserShifts> UserShifts { get; set; } = new List<UserShifts>();
}
