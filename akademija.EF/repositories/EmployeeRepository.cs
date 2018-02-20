using akademija.EF.entities;

namespace akademija.EF.repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NrdAkademijaDbContext context) : base(context)
        {
        }

        public NrdAkademijaDbContext NrdAkademijaDbContext
        {
            get { return Context as NrdAkademijaDbContext; }
        }
    }
}
