using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CategoriesDAO
    {
        private readonly FastFoodDbContext _fastFoodDbContext;
        public CategoriesDAO()
        {
            _fastFoodDbContext = new FastFoodDbContext();
        }
        public List<Categories> GetAllCategories()
        {
            return _fastFoodDbContext.Categories.ToList();
        }
    }
}
