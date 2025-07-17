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
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly PaymentsDAO _paymentsDAO;
        public PaymentsRepository()
        {
            _paymentsDAO = new PaymentsDAO();
        }
        public bool CreatePayment(Payments payments)
        {
            payments.PaymentId = _paymentsDAO.GetNewPaymentId();
            return _paymentsDAO.AddPayment(payments);
        }
    }
}