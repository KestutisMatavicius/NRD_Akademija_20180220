using akademija.Application.main.inventoryType.dto;
using akademija.EF.repositories;
using AutoMapper;
using System.Collections.Generic;

namespace akademija.Application.main.inventoryType
{
    public class InventoryTypeService : IInventoryTypeService
    {
        protected readonly IInventoryTypeRepository _inventoryTypeRepository;
        private readonly IMapper _iMapper;
        public InventoryTypeService(IInventoryTypeRepository inventoryTypeRepository, IMapper iMapper)
        {
            _inventoryTypeRepository = inventoryTypeRepository;
            _iMapper = iMapper;
        }

        public IEnumerable<InventoryTypeDto> GetAll()
        {
            var list = _inventoryTypeRepository.GetAll();
            var listDto = _iMapper.Map<List<InventoryTypeDto>>(list);
            return listDto;
        }
    }
}
