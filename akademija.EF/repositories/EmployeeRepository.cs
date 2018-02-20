using akademija.EF.entities;
using System.Collections.Generic;
using System.Linq;

namespace akademija.EF.repositories
{
    public class EmployeeRepository : IEmployeeRepository//Repository<Employee>, IEmployeeRepository
    {
        protected readonly NrdAkademijaDbContext _context;
        public EmployeeRepository(NrdAkademijaDbContext context)
        {
            _context = context;
        }
        public List<Employee> GetAll()
        {
            return _context.Employee.ToList();
        }
        /*public EmployeeRepository(NrdAkademijaDbContext context) : base(context)
        {
        }

        public List<Employee> GetAllEmployee()
        {
            return NrdAkademijaDbContext.Employee.ToList();
        }

        public NrdAkademijaDbContext NrdAkademijaDbContext
        {
            get { return Context as NrdAkademijaDbContext; }
        }*/
    }
}
