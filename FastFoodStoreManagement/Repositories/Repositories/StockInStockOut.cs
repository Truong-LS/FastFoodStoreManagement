using DataAccessObject;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class StockInStockOut : Interfaces.IStockInStockOut
    {
        public void AddStockLog(InventoryLogs inv)
        {
            StockDAO.Instance.AddStockLog(inv);
        }

        public List<InventoryLogViewModel> GetAllLog()
        {
            return StockDAO.Instance.GetAllLog();
        }

        public List<Materials> GetAllMaterials()
        {
            return StockDAO.Instance.GetAllMaterials();
        }

        public List<Suppliers> GetAllSuppliers()
        {
            return StockDAO.Instance.GetAllSuppliers();
        }
    }
}
