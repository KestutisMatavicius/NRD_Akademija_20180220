using akademija.Application.main.employee;
using akademija.Application.main.employee.dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace akademija.Web.Controllers.employee
{
    [Route("/[controller]")]
    public class EmployeesController : Controller
    {
        protected readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }
        // GET employees
        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
            return _service.GetAllEmployees();
        }

        [HttpGet("{id}")]
        public EmployeeDto Get(int id)
        {
            return _service.GetEmployee(id);
        }

        [HttpDelete("{id}")]
        public void Del(int id)
        {
            _service.DeleteEmployee(id);
        }

        [HttpPost]
        public void Save([FromBody] EmployeeDto item)
        {
            //_service.DeleteEmployee();
        }
    }
}
