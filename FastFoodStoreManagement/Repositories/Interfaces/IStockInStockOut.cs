using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IStockInStockOut
    {
        List<InventoryLogViewModel> GetAllLog();
        List<Materials> GetAllMaterials();
        List<Suppliers> GetAllSuppliers();
        void AddStockLog(InventoryLogs inv);
    }
}
