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
        public IActionResult Get(int id)
        {
            var item = _service.GetEmployee(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Del(int id)
        {
            _service.DeleteEmployee(id);
            return new NoContentResult();
        }

        [HttpPost]
        public IActionResult Save([FromBody] EmployeeDto item)
        {
            _service.Save(item);
            return Ok();
        }
    }
}
