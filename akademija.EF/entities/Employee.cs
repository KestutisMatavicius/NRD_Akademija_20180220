using System;
using System.Collections.Generic;

namespace akademija.EF.entities
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeInventory = new HashSet<EmployeeInventory>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Workplace { get; set; }

        public ICollection<EmployeeInventory> EmployeeInventory { get; set; }
    }
}
