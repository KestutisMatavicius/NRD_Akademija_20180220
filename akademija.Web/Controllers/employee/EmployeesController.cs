using akademija.Application.main.employee;
using akademija.Application.main.employee.dto;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpGet(Name = "GetAllEmployees")]
        public IActionResult Get()
        {

            var employees = _service.GetAllEmployees();
            return Ok(employees);
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


            try
            {
                var employee = _service.GetEmployee(id);
                if (employee == null) return NotFound($"Darbuotojas, kurio id yra {id} nerastas");
                _service.DeleteEmployee(id);
                return new NoContentResult();
            }
            catch (System.Exception)
            {


            }
            return BadRequest();

        }

        [HttpPost]
        public IActionResult Save([FromBody] EmployeeDto item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _service.Save(item);
                string newUri = Url.Link("GetAllEmployees", new { id = item.Id });
                return Created(newUri, item);

            }
            catch (System.Exception)
            {

            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EmployeeDto item)
        {
            try
            {
                _service.Update(id, item);
                string newUri = Url.Link("GetAllEmployees", new { id = item.Id });
                return Created(newUri, item);

            }
            catch (Exception ex)
            {

            }
            return BadRequest("");
        }
    }
}
