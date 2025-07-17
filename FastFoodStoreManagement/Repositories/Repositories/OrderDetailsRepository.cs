using DataAccessObject;
using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        public readonly OrderDetailsDAO _orderDetailsDAO;
        public OrderDetailsRepository()
        {
            _orderDetailsDAO = new OrderDetailsDAO();
        }
        public int CreateOrderDetail(OrderDetails orderDetail)
        {
            orderDetail.DetailId = _orderDetailsDAO.GetNewOrderDetailId();
          var result =   _orderDetailsDAO.CreateOrderDetail(orderDetail);
            if (result)
            {
                return orderDetail.DetailId;
            }
            else
            {
                return 0;
            }
        }
    }
}
