using DataAccessObject;
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
    public class DiscountsService : IDiscountsService
    {
        private readonly IDiscountsRepository _discountsRepository;
        public DiscountsService( )
        {
            _discountsRepository = new DiscountsRepository();
        }
        public Discounts GetDiscountByCode(string code)
        {
            try
            {
                var discounts = _discountsRepository.GetDiscountByCode(code);
                return discounts;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the discount.", ex);
            }
        }

        public bool UseDiscount(string code)
        {
            var result = _discountsRepository.UseDiscount(code);
            if (result)
            {
                return true;
            }
            else
            {
                throw new Exception("Failed to use the discount. It may not be valid or already used.");
            }
        }
    }
}
