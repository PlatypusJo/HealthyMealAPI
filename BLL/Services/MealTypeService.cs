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
    public class MealTypeService : BaseService, IMealTypeService
    {
        public MealTypeService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(MealTypeDto entityDto)
        {
            MealType mealType = new()
            {
                Id = entityDto.Id,
                Name = entityDto.Name,
                Icon = entityDto.Icon,
            };

            await _unitOfWork.MealTypes.Create(mealType);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.Sexes.Exists(id))
                return false;

            // Удаление основных сущностей запрещено.

            return false;
        }

        public async Task<bool> Exists(string id) => await _unitOfWork.MealTypes.Exists(id);

        public async Task<List<MealTypeDto>> GetAll()
        {
            List<MealType> items = await _unitOfWork.MealTypes.GetAll();

            List<MealTypeDto> result = items.Select(x => new MealTypeDto(x)).ToList();

            return result;
        }

        public async Task<MealTypeDto> GetById(string id)
        {
            MealType item = await _unitOfWork.MealTypes.GetById(id);

            return item is null ? null : new(item);
        }

        public async Task<bool> Update(MealTypeDto entityDto)
        {
            if (!await _unitOfWork.MealTypes.Exists(entityDto.Id))
                return false;

            MealType mealType = await _unitOfWork.MealTypes.GetById(entityDto.Id);

            mealType.Id = entityDto.Id;
            mealType.Name = entityDto.Name;
            mealType.Icon = entityDto.Icon;

            await _unitOfWork.MealTypes.Update(mealType);
            return await SaveAsync();
        }

        #endregion
    }
}
