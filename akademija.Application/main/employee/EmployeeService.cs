using akademija.Application.main.employee.dto;
using akademija.EF.repositories;
using AutoMapper;
using System.Collections.Generic;

namespace akademija.Application.main.employee
{
    public class EmployeeService : IEmployeeService
    {
        protected readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _iMapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper iMapper)
        {
            _employeeRepository = employeeRepository;
            _iMapper = iMapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployee()
        {
            var list = _employeeRepository.GetEmployees();
            var blogDto = _iMapper.Map<List<EmployeeDto>>(list);
            return blogDto;
        }
    }
}
