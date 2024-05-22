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
    public class UnitsService : BaseService, IUnitsService
    {
        public UnitsService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(UnitsDto entityDto)
        {
            Units units = new()
            {
                Id = entityDto.Id,
                Name = entityDto.Name
            };

            await _unitOfWork.Units.Create(units);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.Sexes.Exists(id))
                return false;

            List<NutritionalValue> nutritionalValues = await _unitOfWork.NutritionalValues.GetAll();
            foreach(NutritionalValue nutritionalValue in nutritionalValues.Where(x => x.UnitsId == id))
            {
                await _unitOfWork.NutritionalValues.Delete(nutritionalValue.Id);
            }    

            List<Meal> meals = await _unitOfWork.Meals.GetAll();
            foreach(Meal meal in meals.Where(x => x.UnitsId == id))
            {
                await _unitOfWork.Meals.Delete(meal.Id);
            }  
            
            List<ProductToBuy> products = await _unitOfWork.ProductsToBuy.GetAll();
            foreach(ProductToBuy product in products.Where(x => x.UnitsId == id))
            {
                await _unitOfWork.ProductsToBuy.Delete(product.Id);
            }    

            List<Ingredient> ingredients = await _unitOfWork.Ingredients.GetAll();
            foreach(Ingredient ingregient in ingredients.Where(x => x.UnitsId == id))
            {
                await _unitOfWork.Ingredients.Delete(ingregient.Id);
            }

            await _unitOfWork.Units.Delete(id);
            return await SaveAsync();
        }

        public async Task<bool> Exists(string id) => await _unitOfWork.Units.Exists(id);

        public async Task<List<UnitsDto>> GetAll()
        {
            List<Units> items = await _unitOfWork.Units.GetAll();

            List<UnitsDto> result = items.Select(x => new UnitsDto(x)).ToList();

            return result;
        }

        public async Task<UnitsDto> GetById(string id)
        {
            Units item = await _unitOfWork.Units.GetById(id);

            return item is null ? null : new(item);
        }

        public async Task<bool> Update(UnitsDto entityDto)
        {
            if (!await _unitOfWork.Units.Exists(entityDto.Id))
                return false;

            Units units = await _unitOfWork.Units.GetById(entityDto.Id);

            units.Id = entityDto.Id;
            units.Name = entityDto.Name;

            await _unitOfWork.Units.Update(units);
            return await SaveAsync();
        }

        #endregion
    }
}
