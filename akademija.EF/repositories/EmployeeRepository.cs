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

        public Employee GetEmployee(int id)
        {
            return NrdAkademijaDbContext.Employee
                .Include(c => c.EmployeeInventory)
                .ThenInclude(c => c.Inventory)
                .SingleOrDefault(c => c.Id == id);

        }

        public void DeleteEmployee(int id)
        {
            var employee = NrdAkademijaDbContext.Employee.Include(a => a.EmployeeInventory).ThenInclude(c => c.Inventory)
    .SingleOrDefault(a => a.Id == id);

            if (employee != null)
            {
                foreach (var employeeInventory in employee.EmployeeInventory)
                {
                    NrdAkademijaDbContext.EmployeeInventory.Remove(employeeInventory);
                    employeeInventory.Inventory.Taken = employeeInventory.Inventory.Taken - 1;

                }
                NrdAkademijaDbContext.Employee.Remove(employee);
                NrdAkademijaDbContext.SaveChanges();
            }

        }


        public void SaveEmployee(Employee item)
        {

            NrdAkademijaDbContext.Employee.Add(item);
            foreach (var inventory in item.EmployeeInventory)
            {
                var inv = NrdAkademijaDbContext.Inventory.SingleOrDefault(i => i.Id == inventory.InventoryId);
                inv.Taken = inv.Taken + 1;
            }
            NrdAkademijaDbContext.SaveChanges();

        }

        public NrdAkademijaDbContext NrdAkademijaDbContext
        {
            get { return Context as NrdAkademijaDbContext; }
        }
    }
}
