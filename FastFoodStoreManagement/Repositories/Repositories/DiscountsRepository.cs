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
    public class DiscountsRepository : IDiscountsRepository
    {
        private readonly DiscountsDAO _discountsDAO;
        public DiscountsRepository()
        {
            _discountsDAO = new DiscountsDAO();
        }
        public Discounts GetDiscountByCode(string code)
        {
            return _discountsDAO.GetDiscountByCode(code);
        }

        public bool UseDiscount(string code)
        {
            return _discountsDAO.UseDiscount(code);
        }
    }
}
