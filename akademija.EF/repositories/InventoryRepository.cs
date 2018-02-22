using akademija.EF.entities;

namespace akademija.EF.repositories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(NrdAkademijaDbContext context) : base(context)
        {
        }

        //public List<Inventory> GetAllUserInventory(int id)
        //{
        //    return NrdAkademijaDbContext.Inventory
        //        .Include(c => c.EmployeeInventory)
        //        .Where(e => e.Id == id).ToList();


        //}

        public NrdAkademijaDbContext NrdAkademijaDbContext
        {
            get { return Context as NrdAkademijaDbContext; }
        }
    }
}
