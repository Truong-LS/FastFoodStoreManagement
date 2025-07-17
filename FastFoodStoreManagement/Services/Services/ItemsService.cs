using Models;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository _itemsRepository;
        public ItemsService()
        {
            _itemsRepository = new ItemRepository();
        }
        public List<Models.Items> GetAllItems()
        {
            var items = _itemsRepository.GetAllItems();
            return items ?? new List<Models.Items>();
        }
        public List<Items> SearchItems(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return new List<Items>();
            }
            return _itemsRepository.SearchItems(keyword);
        }
        public List<Items> GetItemsByCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                return new List<Items>();
            }
            var items = _itemsRepository.GetItemsByCategory(categoryId);
            return items ?? new List<Items>();
        }
    }
}
