using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PaymentsService : IPaymentsService
    {
        public bool CreatePayment(Payments payments)
        { 
            if (payments == null)
            {
                throw new ArgumentNullException(nameof(payments), "Payment cannot be null");
            }
            var paymentsRepository = new Repositories.Repositories.PaymentsRepository();
            return paymentsRepository.CreatePayment(payments);
        }
    }
}
