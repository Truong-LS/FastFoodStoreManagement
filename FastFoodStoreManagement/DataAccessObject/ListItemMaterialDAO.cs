using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class ListItemMaterialDAO
    {
        private readonly FastFoodDbContext _fastFoodDbContext;
        public ListItemMaterialDAO()
        {
            _fastFoodDbContext = new FastFoodDbContext();
        }
        public List<ListItemMaterial> GetListItemMaterialByItemId(int itemId)
        {
            return _fastFoodDbContext.ListItemMaterial.Where(x => x.ItemId == itemId).ToList();
        }
    }
}
