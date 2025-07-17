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
    public class MaterialsRepository : IMaterialsRepository
    {
        private readonly MaterialsDAO _materialsDAO;
        public MaterialsRepository()
        {
            _materialsDAO = new MaterialsDAO();
        }
        public Materials GetMaterials(int id)
        {
            return _materialsDAO.GetMaterials(id);
        }

        public bool UpdateMaterials(Materials materials)
        {
            return _materialsDAO.UpdateMaterials(materials);
        }
    }
}
