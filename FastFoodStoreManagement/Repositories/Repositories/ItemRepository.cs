using DataAccessObject;
using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ItemRepository : IItemsRepository
    {
        private readonly ItemsDAO _itemsDAO;
        public ItemRepository()
        {
            _itemsDAO = new ItemsDAO();
        }
        public List<Items> GetAllItems()
        {
            return _itemsDAO.GetAllItems();
        }
        public List<Items> SearchItems(string keyword)
        {
            return _itemsDAO.SearchItems(keyword);
        }
        public List<Items> GetItemsByCategory(int categoryId)
        {
            return _itemsDAO.GetItemsByCategory(categoryId);
        }
    }
}
