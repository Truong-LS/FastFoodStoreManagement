using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IMaterialsRepository
    {
        public Materials GetMaterials(int id);
        public bool UpdateMaterials(Materials materials);
    }
}
