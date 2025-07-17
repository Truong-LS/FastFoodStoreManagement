using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderDetailsDAO
    {
        private readonly FastFoodDbContext _fastFoodDbContext;
        public OrderDetailsDAO()
        {
            _fastFoodDbContext = new FastFoodDbContext();
        }
        public bool CreateOrderDetail(OrderDetails orderDetail)
        {
            _fastFoodDbContext.OrderDetails.Add(orderDetail);
            var result = _fastFoodDbContext.SaveChanges();
            return result > 0;
        }
        public int GetNewOrderDetailId()
        {
            var lastOrderDetail = _fastFoodDbContext.OrderDetails.OrderByDescending(od => od.DetailId).FirstOrDefault();
            int newID = 1;
            if (lastOrderDetail != null)
            {
                newID = lastOrderDetail.DetailId + 1;
            }
            return newID;
        }
    }
}
