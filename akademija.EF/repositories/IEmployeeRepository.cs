using akademija.EF.entities;
using System.Collections.Generic;

namespace akademija.EF.repositories
{
    public interface IEmployeeRepository// : IRepository<Employee>
    {
        List<Employee> GetAll();
    }
}