using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class StockDAO
    {
        private readonly FastFoodDbContext _context;
        private static StockDAO _instance;
        private static readonly object _lock = new object();

        public StockDAO()
        {
            _context = new FastFoodDbContext();
        }

        public static StockDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new StockDAO();
                        }
                    }
                }
                return _instance;
            }
        }

        public List<Materials> GetAllMaterials()
        {           
            return _context.Materials.ToList();
        }

        public List<Suppliers> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public List<InventoryLogViewModel> GetAllLog()
        {
            var logs = _context.InventoryLogs
             .Include(log => log.User)
             .Include(log => log.Supplier)
             .Include(log => log.Material) 
             .Select(log => new InventoryLogViewModel
             {
                 LogId = log.LogId,
                 LogType = log.LogType,
                 ChangeQty = log.ChangeQty ?? 0,
                 Unit = log.Unit,
                 Note = log.Note,
                 CreatedAt = log.CreatedAt ?? DateTime.MinValue,
                 UserId = log.UserId ?? 0,
                 MaterialId = log.MaterialId ?? 0,
                 SupplierId = log.SupplierId,

                 UserFullName = log.User != null ? log.User.FullName : "Unknown",
                 SupplierName = log.Supplier != null ? log.Supplier.Name : "N/A",
                 MaterialName = log.Material != null ? log.Material.Name : "N/A"
             })
             .ToList();

            return logs;
        }

        public void AddStockLog(InventoryLogs inv)
        {
            int latestLogId = 0;
            var maxLog = _context.InventoryLogs.OrderByDescending(l => l.LogId).FirstOrDefault();
            if (maxLog != null)
            {
                latestLogId = maxLog.LogId;
            }

            inv.LogId = latestLogId + 1;

            _context.InventoryLogs.Add(inv);

            var material = _context.Materials.FirstOrDefault(m => m.MaterialId == inv.MaterialId);
            if (material != null)
            {
                int currentQty = material.StockQty ?? 0;
                int changeQty = inv.ChangeQty ?? 0;

                currentQty += changeQty; // Cộng trực tiếp

                if (currentQty < 0)
                    currentQty = 0; // Ngăn tồn kho âm

                material.StockQty = currentQty;
            }

            _context.SaveChanges();
        }

    }
}
