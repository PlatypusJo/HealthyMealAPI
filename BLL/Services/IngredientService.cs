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
    public class IngredientService : BaseService, IIngredientService
    {
        public IngredientService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(IngredientDto entityDto)
        {
            Ingredient item = new()
            {
                Id = entityDto.Id,
                FoodId = entityDto.FoodId,
                RecipeId = entityDto.RecipeId,
                UnitsId = entityDto.UnitsId,
                UnitsAmount = entityDto.UnitsAmount,
            };

            await _unitOfWork.Ingredients.Create(item);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.Ingredients.Exists(id))
                return false;

            await _unitOfWork.Ingredients.Delete(id);

            return await SaveAsync();
        }

        public async Task<bool> Exists(string id) => await _unitOfWork.Ingredients.Exists(id);

        public async Task<List<IngredientDto>> GetAll()
        {
            List<Ingredient> items = await _unitOfWork.Ingredients.GetAll();

            List<IngredientDto> result = items.Select(x => new IngredientDto(x)).ToList();

            foreach (IngredientDto item in result)
            {
                Food food = await _unitOfWork.Foods.GetById(item.FoodId);
                Units units = await _unitOfWork.Units.GetById(item.UnitsId);

                item.Name = food.Name;
                item.UnitsName = units.Name;
            }

            return result;
        }

        public async Task<IngredientDto> GetById(string id)
        {
            Ingredient item = await _unitOfWork.Ingredients.GetById(id);

            IngredientDto result = item is null ? null : new IngredientDto(item);

            if (result is null)
                return null;

            Food food = await _unitOfWork.Foods.GetById(result.FoodId);
            Units units = await _unitOfWork.Units.GetById(result.UnitsId);

            result.Name = food.Name;
            result.UnitsName = units.Name;

            return result;
        }

        public async Task<bool> Update(IngredientDto entityDto)
        {
            if (!await _unitOfWork.Ingredients.Exists(entityDto.Id))
                return false;

            Ingredient item = await _unitOfWork.Ingredients.GetById(entityDto.Id);

            item.Id = entityDto.Id;
            item.RecipeId = entityDto.RecipeId;
            item.FoodId = entityDto.FoodId;
            item.UnitsId = entityDto.UnitsId;
            item.UnitsAmount = entityDto.UnitsAmount;

            await _unitOfWork.Ingredients.Update(item);
            return await SaveAsync();
        }

        #endregion

        public async Task<List<IngredientDto>> GetRecipeIngredients(string recipeId)
        {
            List<Ingredient> items = await _unitOfWork.Ingredients.GetAll();

            List<IngredientDto> result = items
                .Select(x => new IngredientDto(x))
                .Where(x => x.RecipeId == recipeId)
                .ToList();

            foreach (IngredientDto item in result)
            {
                Food food = await _unitOfWork.Foods.GetById(item.FoodId);
                Units units = await _unitOfWork.Units.GetById(item.UnitsId);

                item.Name = food.Name;
                item.UnitsName = units.Name;
            }

            return result;
        }
    }
}
