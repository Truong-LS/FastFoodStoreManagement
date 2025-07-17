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
    public class ListItemMaterialRepository : IListItemMaterialRepository
    {
        private readonly ListItemMaterialDAO _listItemMaterialDAO;

        public ListItemMaterialRepository()
        {
            _listItemMaterialDAO = new ListItemMaterialDAO();
        }

        public List<ListItemMaterial> GetListItemMaterialByItemId(int itemId)
        {
            return _listItemMaterialDAO.GetListItemMaterialByItemId(itemId);
        }
    }
}
