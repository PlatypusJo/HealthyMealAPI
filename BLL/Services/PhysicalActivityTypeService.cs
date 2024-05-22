using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services.Abstract;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PhysicalActivityTypeService : BaseService, IPhysicalActivityTypeService
    {
        public PhysicalActivityTypeService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(PhysicalActivityTypeDto entityDto)
        {
            PhysicalActivityType item = new()
            {
                Id = entityDto.Id,
                Name = entityDto.Name,
                ActivityFactor = entityDto.ActivityFactor,
                Description = entityDto.Description,
            };

            await _unitOfWork.PhysicalActivityTypes.Create(item);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.PhysicalActivityTypes.Exists(id))
                return false;

            // Удаление основных сущностей запрещено.

            return false;
        }

        public async Task<bool> Exists(string id) => await _unitOfWork.PhysicalActivityTypes.Exists(id);

        public async Task<List<PhysicalActivityTypeDto>> GetAll()
        {
            List<PhysicalActivityType> items = await _unitOfWork.PhysicalActivityTypes.GetAll();

            List<PhysicalActivityTypeDto> result = items.Select(x => new PhysicalActivityTypeDto(x)).ToList();

            return result;
        }

        public async Task<PhysicalActivityTypeDto> GetById(string id)
        {
            PhysicalActivityType item = await _unitOfWork.PhysicalActivityTypes.GetById(id);

            return item is null ? null : new(item);
        }

        public async Task<bool> Update(PhysicalActivityTypeDto entityDto)
        {
            if (!await _unitOfWork.PhysicalActivityTypes.Exists(entityDto.Id))
                return false;

            PhysicalActivityType item = await _unitOfWork.PhysicalActivityTypes.GetById(entityDto.Id);

            item.Id = entityDto.Id;
            item.Name = entityDto.Name;
            item.ActivityFactor = entityDto.ActivityFactor;
            item.Description = entityDto.Description;

            await _unitOfWork.PhysicalActivityTypes.Update(item);
            return await SaveAsync();
        }

        #endregion

        
    }
}
