using Models;

namespace Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        IEnumerable<Discounts> GetAllDiscounts();
        Discounts GetDiscountById(int discountId);
        void AddDiscount(Discounts discount);
        void UpdateDiscount(Discounts discount);
        void DeleteDiscount(int discountId);
    }
}
