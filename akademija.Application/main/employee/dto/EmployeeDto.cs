using akademija.Application.main.inventory.dto;
using System.Collections.Generic;

namespace akademija.Application.main.employee.dto
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            Inventory = new HashSet<InventoryViewDto>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Workplace { get; set; }

        public ICollection<InventoryViewDto> Inventory { get; set; }
    }
}
