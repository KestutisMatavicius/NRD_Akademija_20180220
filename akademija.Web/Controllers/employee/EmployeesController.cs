using akademija.Application.main.employee;
using akademija.EF.entities;
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
        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _service.GetAllEmployee();
        }
    }
}
