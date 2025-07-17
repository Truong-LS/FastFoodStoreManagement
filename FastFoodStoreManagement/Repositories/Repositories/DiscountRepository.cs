using DataAccessObject;
using Models;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DiscountDAO _discountDAO;

        public DiscountRepository()
        {
            _discountDAO = new DiscountDAO();
        }

        public IEnumerable<Discounts> GetAllDiscounts()
        {
            return _discountDAO.GetAllDiscounts();
        }

        public Discounts GetDiscountById(int discountId)
        {
            return _discountDAO.GetDiscountById(discountId);
        }

        public void AddDiscount(Discounts discount)
        {
            _discountDAO.AddDiscount(discount);
        }

        public void UpdateDiscount(Discounts discount)
        {
            _discountDAO.UpdateDiscount(discount);
        }

        public void DeleteDiscount(int discountId)
        {
            _discountDAO.DeleteDiscount(discountId);
        }
    }
}
