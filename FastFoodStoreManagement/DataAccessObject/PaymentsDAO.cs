using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class PaymentsDAO
    {
        private readonly FastFoodDbContext _fastFoodDbContext;
        public PaymentsDAO()
        {
            _fastFoodDbContext = new FastFoodDbContext();
        }
        public bool AddPayment(Payments payment)
        {
            _fastFoodDbContext.Payments.Add(payment);
            var result = _fastFoodDbContext.SaveChanges();
            return result > 0;
        }
        public int GetNewPaymentId()
        {
            var lastPayment = _fastFoodDbContext.Payments.OrderByDescending(p => p.PaymentId).FirstOrDefault();
            int newID = 1;
            if (lastPayment != null)
            {
                newID = (int)lastPayment.OrderId + 1;
            }
            return newID;
        }
    }
}
