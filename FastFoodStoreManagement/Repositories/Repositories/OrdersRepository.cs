using DataAccessObject;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersDAO _ordersDAO;
        public OrdersRepository()
        {
            _ordersDAO = new OrdersDAO();
        }
        public int CreateOrder(Models.Orders order)
        {
            order.OrderId = _ordersDAO.GetNewOrderId();
            var result = _ordersDAO.CreateOrder(order);
            if (result)
            {
                return order.OrderId;
            }
            else
            {
                return 0;
            }
        }
    }
}
