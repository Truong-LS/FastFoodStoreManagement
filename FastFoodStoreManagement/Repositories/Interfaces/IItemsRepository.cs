using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IItemsRepository
    {
        List<Items> GetAllItems();
        List<Items> SearchItems(string keyword);
        List<Items> GetItemsByCategory(int categoryId);
    }
}
