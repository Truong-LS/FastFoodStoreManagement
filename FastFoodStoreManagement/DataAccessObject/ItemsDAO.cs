using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class ItemsDAO
    {
        private readonly FastFoodDbContext _fastFoodDbContext;
        public ItemsDAO()
        {
            _fastFoodDbContext = new FastFoodDbContext();
        }
        public List<Items> GetAllItems()
        {
            return _fastFoodDbContext.Items.ToList();
        }
        public List<Items> SearchItems(string keyword)
        {
            return _fastFoodDbContext.Items
                .Where(item => item.Name.Contains(keyword))
                .ToList();
        }
        public List<Items> GetItemsByCategory(int categoryID)
        {
            return _fastFoodDbContext.Items
                .Where(item => item.CategoryId == categoryID)
                .ToList();
        }
    }
}
