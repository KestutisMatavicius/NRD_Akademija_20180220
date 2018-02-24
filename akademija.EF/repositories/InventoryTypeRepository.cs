using akademija.EF.entities;

namespace akademija.EF.repositories
{
    public class InventoryTypeRepository : Repository<InventoryType>, IInventoryTypeRepository
    {
        public InventoryTypeRepository(NrdAkademijaDbContext context) : base(context)
        {
        }

        public NrdAkademijaDbContext NrdAkademijaDbContext
        {
            get { return Context as NrdAkademijaDbContext; }
        }
    }
}
