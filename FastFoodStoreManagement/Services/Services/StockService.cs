using Models;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class StockService : IStockService
    {
        private readonly IStockManagement _stockManagement;
        private readonly IStockInStockOut _stockInStockOut;
        public StockService()
        {
            _stockManagement = new StockManagement();
            _stockInStockOut = new StockInStockOut();
        }

        public void AddStockLog(InventoryLogs inv)
        {
            _stockInStockOut.AddStockLog(inv);
        }

        public List<InventoryLogViewModel> GetAllLog()
        {
            if(_stockManagement == null)
            {
                throw new InvalidOperationException("Stock In/ Stock Out service is not initialized.");
            }
            return _stockInStockOut.GetAllLog();
        }

        public List<Materials> GetAllMaterials()
        {
            if(_stockManagement == null)
            {
                throw new InvalidOperationException("Stock management service is not initialized.");
            }
            return _stockManagement.GetAllMaterials();
        }

        public List<Suppliers> GetAllSuppliers()
        {
            if(_stockInStockOut == null)
            {
                throw new InvalidOperationException("Stock supplier service is not initialized.");
            }
            return _stockInStockOut.GetAllSuppliers();
        }
    }
}
