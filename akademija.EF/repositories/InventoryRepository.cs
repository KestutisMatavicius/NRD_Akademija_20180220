using akademija.EF.entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace akademija.EF.repositories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(NrdAkademijaDbContext context) : base(context)
        {
        }

        public List<Inventory> GetInventory()
        {
            return NrdAkademijaDbContext.Inventory
              .Include(c => c.TypeNavigation).ToList();

        }

        public NrdAkademijaDbContext NrdAkademijaDbContext
        {
            get { return Context as NrdAkademijaDbContext; }
        }
    }
}
