using akademija.Application.main.employee.dto;
using System.Collections.Generic;

namespace akademija.Application.main.employee
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployee();
    }
}
