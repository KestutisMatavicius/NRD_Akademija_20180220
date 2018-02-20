using System;
using System.Collections.Generic;

namespace akademija.EF.entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            EmployeeInventory = new HashSet<EmployeeInventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public int? Taken { get; set; }
        public int? Type { get; set; }

        public InventoryType TypeNavigation { get; set; }
        public ICollection<EmployeeInventory> EmployeeInventory { get; set; }
    }
}
