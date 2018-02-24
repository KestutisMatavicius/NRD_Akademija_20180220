using akademija.Application.main.inventoryType;
using akademija.Application.main.inventoryType.dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace akademija.Web.Controllers.inventoryType
{
    [Route("/inventorytypes")]
    public class InventoryTypeController : Controller
    {
        protected readonly IInventoryTypeService _service;
        public InventoryTypeController(IInventoryTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<InventoryTypeDto> Get()
        {
            return _service.GetAll();
        }
    }
}
