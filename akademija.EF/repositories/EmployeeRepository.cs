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

        public void UpdateEmployee(int id, Employee item)
        {
            var oldEmployee = GetEmployee(id);
            oldEmployee.Email = item.Email;
            oldEmployee.FirstName = item.FirstName;
            oldEmployee.Workplace = item.Workplace;


            List<int> oldInventoryIdList = oldEmployee.EmployeeInventory.Select(p => p.InventoryId).ToList();
            List<int> newInventoryIdList = item.EmployeeInventory.Select(p => p.InventoryId).ToList();
            List<int> newAdded = newInventoryIdList.Except(oldInventoryIdList).ToList();
            List<int> oldRemoved = oldInventoryIdList.Except(newInventoryIdList).ToList();

            foreach (int newId in newAdded)
            {
                var inventory = NrdAkademijaDbContext.Inventory.SingleOrDefault(p => p.Id == newId);
                oldEmployee.EmployeeInventory.Add(new EmployeeInventory() { InventoryId = inventory.Id });
                var inv = NrdAkademijaDbContext.Inventory.SingleOrDefault(p => p.Id == newId);
                inv.Taken = inv.Taken + 1;
            }

            foreach (var oldId in oldRemoved)
            {
                var oldInventory = oldEmployee.EmployeeInventory.SingleOrDefault(p => p.InventoryId == oldId);
                oldEmployee.EmployeeInventory.Remove(oldInventory);
                var inv = NrdAkademijaDbContext.Inventory.SingleOrDefault(p => p.Id == oldId);
                inv.Taken = inv.Taken - 1;
            }

            NrdAkademijaDbContext.SaveChanges();
        }

        public NrdAkademijaDbContext NrdAkademijaDbContext
        {
            get { return Context as NrdAkademijaDbContext; }
        }
    }
}
