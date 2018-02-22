using akademija.EF.entities;
using akademija.EF.repositories;
using System.Collections.Generic;

namespace akademija.Application.main.inventory
{
    public class InventoryService : IInventoryService
    {
        protected readonly IInventoryRepository _inventory;
        public InventoryService(IInventoryRepository inventory)
        {
            _inventory = inventory;
        }

        public IEnumerable<Inventory> GetUserInventory(int id)
        {
            return _inventory.GetAll();

        }


    }
}
