using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrdersDAO
    {
        private readonly FastFoodDbContext _fastFoodDbContext;
        public OrdersDAO()
        {
            _fastFoodDbContext = new FastFoodDbContext();
        }
        public bool CreateOrder(Orders oder)
        {
            _fastFoodDbContext.Orders.Add(oder);
            var result = _fastFoodDbContext.SaveChanges();
            return result > 0;
        }
        public int GetNewOrderId()
        {
            var lastOrder = _fastFoodDbContext.Orders.OrderByDescending(o => o.OrderId).FirstOrDefault();
            int newID = 1;
            if (lastOrder != null)
            {
                newID = lastOrder.OrderId + 1;
            }
            return newID;
        }
    }
}
