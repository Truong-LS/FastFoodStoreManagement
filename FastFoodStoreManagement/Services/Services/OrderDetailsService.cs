using Models;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Services.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService()
        {
            _orderDetailsRepository = new OrderDetailsRepository();
        }
        public int CreateOrderDetail(OrderDetails orderDetail)
        {
            if (orderDetail == null)
            {
                throw new ArgumentNullException(nameof(orderDetail), "Order Detail cannot be null");
            }
            var result = _orderDetailsRepository.CreateOrderDetail(orderDetail);
            if (result == 0)
            {
                throw new Exception("Failed to create order");
            }
            else { return result; }
        }
    }
}
