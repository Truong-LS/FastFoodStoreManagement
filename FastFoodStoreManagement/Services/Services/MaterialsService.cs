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
    public class MaterialsService : IMaterialsService
    {
        private readonly IMaterialsRepository _materialsRepository;
        private readonly IListItemMaterialRepository _listItemMaterialRepository;
        public MaterialsService()
        {
            _materialsRepository = new MaterialsRepository();
            _listItemMaterialRepository = new ListItemMaterialRepository();
        }
        public bool UpdateMaterialsByOrderDetail(OrderDetails orderDetails)
        {
            var listItemMaterial = _listItemMaterialRepository.GetListItemMaterialByItemId(orderDetails.ItemId);
            foreach (var item in listItemMaterial)
            {
                var material = _materialsRepository.GetMaterials(item.MaterialId);
                if (material == null || material.StockQty < item.QuantityUsed * orderDetails.Quantity)
                {
                    return false;
                }
                material.StockQty -= item.QuantityUsed * orderDetails.Quantity;
                _materialsRepository.UpdateMaterials(material);
            }
            return true;
        }
    }
}
