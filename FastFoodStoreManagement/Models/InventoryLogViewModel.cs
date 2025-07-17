using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class InventoryLogViewModel
    {
        public int LogId { get; set; }
        public string? LogType { get; set; }
        public int? ChangeQty { get; set; }
        public string? Unit { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int UserId { get; set; }
        public int MaterialId { get; set; }
        public int? SupplierId { get; set; }

        public string? UserFullName { get; set; }
        public string? SupplierName { get; set; }
        public string? MaterialName { get; set; }

    }
}
