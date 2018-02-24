using akademija.Application.main.inventory.dto;
using akademija.EF.repositories;
using AutoMapper;
using System.Collections.Generic;

namespace akademija.Application.main.inventory
{
    public class InventoryService : IInventoryService
    {
        protected readonly IInventoryRepository _inventory;
        private readonly IMapper _iMapper;
        public InventoryService(IInventoryRepository inventory, IMapper iMapper)
        {
            _inventory = inventory;
            _iMapper = iMapper;
        }


        public IEnumerable<InventoryDto> GetAll()
        {
            var list = _inventory.GetAll();
            var listDto = _iMapper.Map<List<InventoryDto>>(list);
            return listDto;

        }


    }
}
