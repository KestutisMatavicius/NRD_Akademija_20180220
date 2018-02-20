using akademija.EF.entities;
using System.Collections.Generic;

namespace akademija.Application.main.employee
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();
    }
}
