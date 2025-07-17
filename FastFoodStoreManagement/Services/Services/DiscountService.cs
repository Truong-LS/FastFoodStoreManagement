using Models;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Interfaces;

namespace Services.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService()
        {
            _discountRepository = new DiscountRepository();
        }

        public IEnumerable<Discounts> GetAllDiscounts()
        {
            return _discountRepository.GetAllDiscounts();
        }

        public Discounts GetDiscountById(int discountId)
        {
            return _discountRepository.GetDiscountById(discountId);
        }

        public void AddDiscount(Discounts discount)
        {
            _discountRepository.AddDiscount(discount);
        }

        public void UpdateDiscount(Discounts discount)
        {
            _discountRepository.UpdateDiscount(discount);
        }

        public void DeleteDiscount(int discountId)
        {
            _discountRepository.DeleteDiscount(discountId);
        }
    }
}
