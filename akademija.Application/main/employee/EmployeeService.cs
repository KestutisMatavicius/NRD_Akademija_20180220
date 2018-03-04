using akademija.Application.main.employee.dto;
using akademija.EF.entities;
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

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var list = _employeeRepository.GetEmployees();
            var listDto = _iMapper.Map<List<EmployeeDto>>(list);
            return listDto;
        }

        public EmployeeDto GetEmployee(int id)
        {
            var item = _employeeRepository.GetEmployee(id);
            var itemDto = _iMapper.Map<EmployeeDto>(item);
            return itemDto;
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }

        public void Save(EmployeeDto item)
        {
            var employee = _iMapper.Map<Employee>(item);
            _employeeRepository.SaveEmployee(employee);

        }

        public void Update(int id, EmployeeDto item)
        {
            var employee = _iMapper.Map<Employee>(item);
            _employeeRepository.UpdateEmployee(id, employee);

        }
    }
}
