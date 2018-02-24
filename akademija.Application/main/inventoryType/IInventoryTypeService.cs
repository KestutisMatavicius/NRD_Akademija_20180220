using akademija.Application.main.inventoryType.dto;
using System.Collections.Generic;

namespace akademija.Application.main.inventoryType
{
    public interface IInventoryTypeService
    {
        IEnumerable<InventoryTypeDto> GetAll();
    }
}