using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStockService
    {
        public List<Materials> GetAllMaterials();

        public List<InventoryLogViewModel> GetAllLog();

        public List<Suppliers> GetAllSuppliers();

        public void AddStockLog(InventoryLogs inv);
    }
}
