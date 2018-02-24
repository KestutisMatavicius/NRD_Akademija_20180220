using System.Collections.Generic;

namespace akademija.Application.main.inventory.dto
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public int? Taken { get; set; }
        public int? Type { get; set; }
    }
}
