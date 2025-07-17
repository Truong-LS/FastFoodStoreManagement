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
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly CategoriesDAO _categoriesDAO;
        public CategoriesRepository()
        {
            _categoriesDAO = new CategoriesDAO();
        }
        public List<Categories> GetAllCategories()
        {
            return _categoriesDAO.GetAllCategories();
        }
    }
}
