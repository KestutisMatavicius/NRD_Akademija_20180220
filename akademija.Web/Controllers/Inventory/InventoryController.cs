using akademija.Application.main.inventory;
using akademija.Application.main.inventory.dto;
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
        public IEnumerable<InventoryDto> Get()
        {
            return _service.GetAll();
        }
    }
}
