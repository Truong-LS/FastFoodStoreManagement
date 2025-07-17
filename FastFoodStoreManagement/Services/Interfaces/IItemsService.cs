using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IItemsService
    {
        List<Models.Items> GetAllItems();
        List<Items> SearchItems(string keyword);
        List<Items> GetItemsByCategory(int categoryId);
    }
}
