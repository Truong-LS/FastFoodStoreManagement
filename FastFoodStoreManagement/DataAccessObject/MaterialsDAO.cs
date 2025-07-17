using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace DataAccessObject
{
    public class MaterialsDAO
    {
        public readonly FastFoodDbContext _fastFoodDbContext;
        public MaterialsDAO()
        {
            _fastFoodDbContext = new FastFoodDbContext();
        }
        public Materials GetMaterials(int id)
        {
            return _fastFoodDbContext.Materials.FirstOrDefault(x => x.MaterialId == id);
        }
        public bool UpdateMaterials(Materials materials)
        {
            _fastFoodDbContext.Materials.Update(materials);
            var result = _fastFoodDbContext.SaveChanges();
            return result > 0;
        }
    }
}
