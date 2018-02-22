using akademija.EF.entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace akademija.EF.repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NrdAkademijaDbContext context) : base(context)
        {
        }

        public List<Employee> GetEmployees()
        {
            return NrdAkademijaDbContext.Employee
                .Include(c => c.EmployeeInventory)
                .ThenInclude(c => c.Inventory)
                .ToList();
        }

        public NrdAkademijaDbContext NrdAkademijaDbContext
        {
            get { return Context as NrdAkademijaDbContext; }
        }
    }
}
