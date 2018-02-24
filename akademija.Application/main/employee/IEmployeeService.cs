using akademija.Application.main.employee.dto;
using System.Collections.Generic;

namespace akademija.Application.main.employee
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployee(int id);
        void DeleteEmployee(int id);
        void Save(EmployeeDto item);
    }
}
