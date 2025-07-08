using System;
using System.Collections.Generic;

namespace Models;

public partial class UserShifts
{
    public int UserShiftId { get; set; }

    public int UserId { get; set; }

    public int ShiftId { get; set; }

    public DateTime? WorkDate { get; set; }

    public DateTime? CheckIn { get; set; }

    public int? ShiftNum { get; set; }

    public DateTime? CheckOut { get; set; }

    public virtual Shifts Shift { get; set; } = null!;

    public virtual Users User { get; set; } = null!;
}
