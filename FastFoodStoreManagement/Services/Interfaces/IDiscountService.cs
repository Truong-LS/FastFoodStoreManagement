using Models;

namespace Services.Interfaces
{
    public interface IDiscountService
    {
        IEnumerable<Discounts> GetAllDiscounts();
        Discounts GetDiscountById(int discountId);
        void AddDiscount(Discounts discount);
        void UpdateDiscount(Discounts discount);
        void DeleteDiscount(int discountId);
        Discounts GetDiscountByCode(string code);
    }
}
