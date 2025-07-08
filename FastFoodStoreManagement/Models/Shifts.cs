using System;
using System.Collections.Generic;

namespace Models;

public partial class Shifts
{
    public int ShiftId { get; set; }

    public string? Name { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? IsActive { get; set; }

    public virtual ICollection<UserShifts> UserShifts { get; set; } = new List<UserShifts>();
}
