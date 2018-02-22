using akademija.EF.entities;
using System.Collections.Generic;

namespace akademija.Application.main.inventory
{

    public interface IInventoryService
    {
        IEnumerable<Inventory> GetUserInventory(int id);
    }
}
