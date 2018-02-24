using akademija.EF.entities;
using System.Collections.Generic;

namespace akademija.EF.repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void DeleteEmployee(int id);
    }
}