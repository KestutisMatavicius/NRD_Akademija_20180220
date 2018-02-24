using akademija.EF.entities;
using System.Collections.Generic;

namespace akademija.EF.repositories
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        List<Inventory> GetInventory();
    }
}