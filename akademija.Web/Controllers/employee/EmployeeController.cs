using akademija.Application.main.employee;
using akademija.EF.entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace akademija.Web.Controllers.employee
{
    [Route("api/employee/[controller]")]
    public class EmployeeController : Controller
    {
        protected readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _service.GetAllEmployee();
        }
    }
}
