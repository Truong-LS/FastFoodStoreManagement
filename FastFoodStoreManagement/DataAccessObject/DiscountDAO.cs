using Models;
using DataAccessObject;

namespace DataAccessObject
{
    public class DiscountDAO
    {
        private readonly FastFoodDbContext _context;

        public DiscountDAO()
        {
            _context = new FastFoodDbContext();
        }

        public IEnumerable<Discounts> GetAllDiscounts()
        {
            return _context.Discounts.ToList();
        }

        public Discounts GetDiscountById(int discountId)
        {
            return _context.Discounts.Find(discountId);
        }

        public Discounts GetDiscountByCode(string code)
        {
            return _context.Discounts.FirstOrDefault(d => d.Code == code);
        }

        public void AddDiscount(Discounts discount)
        {
            // Manually generate a new unique DiscountId
            var maxId = _context.Discounts.Any() ? _context.Discounts.Max(d => d.DiscountId) : 0;
            discount.DiscountId = maxId + 1;

            _context.Discounts.Add(discount);
            _context.SaveChanges();
        }

        public void UpdateDiscount(Discounts discount)
        {
            var existingDiscount = _context.Discounts.Find(discount.DiscountId);
            if (existingDiscount != null)
            {
                existingDiscount.Code = discount.Code;
                existingDiscount.StartDate = discount.StartDate;
                existingDiscount.EndDate = discount.EndDate;
                existingDiscount.Type = discount.Type;
                existingDiscount.Value = discount.Value;
                existingDiscount.IsActive = discount.IsActive;

                _context.SaveChanges();
            }
        }

        public void DeleteDiscount(int discountId)
        {
            var discount = _context.Discounts.Find(discountId);
            if (discount != null)
            {
                _context.Discounts.Remove(discount);
                _context.SaveChanges();
            }
        }
    }
}
