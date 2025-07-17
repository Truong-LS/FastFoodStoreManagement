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

        public Discounts GetDiscountByCode(string code)
        {
            return _discountRepository.GetDiscountByCode(code);
        }

        public void AddDiscount(Discounts discount)
        {
            if (_discountRepository.GetDiscountByCode(discount.Code) != null)
            {
                throw new InvalidOperationException("Mã coupon đã tồn tại.");
            }
            _discountRepository.AddDiscount(discount);
        }

        public void UpdateDiscount(Discounts discount)
        {
            var existingDiscount = _discountRepository.GetDiscountById(discount.DiscountId);
            if (existingDiscount != null && existingDiscount.Code != discount.Code && _discountRepository.GetDiscountByCode(discount.Code) != null)
            {
                throw new InvalidOperationException("Mã coupon đã tồn tại.");
            }
            _discountRepository.UpdateDiscount(discount);
        }

        public void DeleteDiscount(int discountId)
        {
            _discountRepository.DeleteDiscount(discountId);
        }

        public IEnumerable<Discounts> SearchDiscountsByCode(string code)
        {
            return _discountRepository.GetAllDiscounts().Where(d => d.Code.ToLower().Contains(code.ToLower())).ToList();
        }
    }
}
