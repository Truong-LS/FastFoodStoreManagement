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
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersService()
        {
            _ordersRepository = new OrdersRepository();
        }
        public int CreateOrder(Orders order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null");
            }
            var result = _ordersRepository.CreateOrder(order);
            if (result == 0)
            {
                throw new Exception("Failed to create order");
            }
            else { return result; }
        }
    }
}
