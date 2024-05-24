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
    public class NutritionalValueService : BaseService, INutritionalValueService
    {
        public NutritionalValueService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(NutritionalValueDto entityDto)
        {
            NutritionalValue item = new()
            {
                Id = entityDto.Id,
                FoodId = entityDto.FoodId,
                UnitsId = entityDto.UnitsId,
                Kcal = entityDto.Kcal,
                Proteins = entityDto.Proteins,
                Fats = entityDto.Fats,
                Carbohydrates = entityDto.Carbohydrates,
                UnitsAmount = entityDto.UnitsAmount,
                IsDefault = entityDto.IsDefault,
            };

            await _unitOfWork.NutritionalValues.Create(item);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.NutritionalValues.Exists(id))
                return false;

            await _unitOfWork.NutritionalValues.Delete(id);

            return await SaveAsync();
        }

        public async Task<bool> Exists(string id) => await _unitOfWork.NutritionalValues.Exists(id);

        public async Task<List<NutritionalValueDto>> GetAll()
        {
            List<NutritionalValue> items = await _unitOfWork.NutritionalValues.GetAll();

            List<NutritionalValueDto> result = items.Select(x => new NutritionalValueDto(x)).ToList();

            return result;
        }

        public async Task<NutritionalValueDto> GetById(string id)
        {
            NutritionalValue item = await _unitOfWork.NutritionalValues.GetById(id);

            return item is null ? null : new(item);
        }

        public async Task<bool> Update(NutritionalValueDto entityDto)
        {
            if (!await _unitOfWork.CookingSteps.Exists(entityDto.Id))
                return false;

            NutritionalValue item = await _unitOfWork.NutritionalValues.GetById(entityDto.Id);

            item.Id = entityDto.Id;
            item.FoodId = entityDto.FoodId;
            item.UnitsId = entityDto.UnitsId;
            item.Kcal = entityDto.Kcal;
            item.Proteins = entityDto.Proteins;
            item.Fats = entityDto.Fats;
            item.Carbohydrates = entityDto.Carbohydrates;
            item.IsDefault = entityDto.IsDefault;
            item.UnitsAmount = entityDto.UnitsAmount;

            await _unitOfWork.NutritionalValues.Update(item);
            return await SaveAsync();
        }

        #endregion
        
        public async Task<NutritionalValueDto> GetFoodNutritionalValue(string foodId, string unitsId)
        {
            List<NutritionalValue> items = await _unitOfWork.NutritionalValues.GetAll();

            NutritionalValue result = items.Find(x => x.FoodId == foodId && x.UnitsId == unitsId);

            return result is null ? null : new(result);
        }
    }
}
