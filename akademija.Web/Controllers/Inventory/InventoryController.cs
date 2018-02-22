using akademija.Application.main.inventory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace akademija.Web.Controllers.Inventory
{
    [Route("/[controller]")]
    public class InventoryController : Controller
    {
        protected readonly IInventoryService _service;

        public InventoryController(IInventoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<akademija.EF.entities.Inventory> Get()
        {
            return _service.GetUserInventory(2);
        }
    }
}
