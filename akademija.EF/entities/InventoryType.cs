using System;
using System.Collections.Generic;

namespace akademija.EF.entities
{
    public partial class InventoryType
    {
        public InventoryType()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Inventory> Inventory { get; set; }
    }
}
