using akademija.Application.main.employeeInventory.dto;
using System.Collections.Generic;

namespace akademija.Application.main.employee.dto
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            EmployeeInventory = new HashSet<EmployeeInventoryDto>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Workplace { get; set; }

        public ICollection<EmployeeInventoryDto> EmployeeInventory { get; set; }
    }
}
