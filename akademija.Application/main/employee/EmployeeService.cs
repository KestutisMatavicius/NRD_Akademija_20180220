using akademija.EF.entities;
using akademija.EF.repositories;
using System.Collections.Generic;

namespace akademija.Application.main.employee
{
    public class EmployeeService : IEmployeeService
    {
        protected readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAllEmployee()
        {
            var list = _employeeRepository.GetAll();
            return list;
        }
    }
}
