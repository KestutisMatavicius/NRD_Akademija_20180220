using akademija.Application.main.inventory.dto;
using System.Collections.Generic;

namespace akademija.Application.main.inventory
{

    public interface IInventoryService
    {
        IEnumerable<InventoryDto> GetAll();
    }
}
