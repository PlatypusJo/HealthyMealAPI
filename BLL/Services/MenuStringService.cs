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
    public class MenuStringService : BaseService, IMenuStringService
    {
        public MenuStringService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(MenuStringDto entityDto)
        {
            MenuString item = new()
            {
                Id = entityDto.Id,
                MealTypeId = entityDto.MealTypeId,
                RecipeId = entityDto.RecipeId,
                MenuId = entityDto.MenuId,
            };

            await _unitOfWork.MenuStrings.Create(item);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.MenuStrings.Exists(id))
                return false;

            await _unitOfWork.MenuStrings.Delete(id);

            return await SaveAsync();
        }

        public async Task<bool> Exists(string id) => await _unitOfWork.MenuStrings.Exists(id);

        public async Task<List<MenuStringDto>> GetAll()
        {
            List<MenuString> items = await _unitOfWork.MenuStrings.GetAll();

            List<MenuStringDto> result = items.Select(x => new MenuStringDto(x)).ToList();

            List<NutritionalValue> nutritionalValues = await _unitOfWork.NutritionalValues.GetAll();
            foreach (MenuStringDto item in result)
            {
                Recipe recipe = await _unitOfWork.Recipes.GetById(item.RecipeId);
                Food food = await _unitOfWork.Foods.GetById(recipe.FoodId);
                NutritionalValue nutritionalValue = nutritionalValues.Find(x => x.FoodId == food.Id && x.IsDefault);

                item.RecipeName = food.Name;
                item.RecipePhoto = food.Image;
                item.CookingTime = recipe.CookingTime;
                item.Kcal = nutritionalValue.Kcal;
                item.Proteins = nutritionalValue.Proteins;
                item.Fats = nutritionalValue.Fats;
                item.Carbohydrates = nutritionalValue.Carbohydrates;
            }

            return result;
        }

        public async Task<MenuStringDto> GetById(string id)
        {
            MenuString item = await _unitOfWork.MenuStrings.GetById(id);

            MenuStringDto result = item is null ? null : new MenuStringDto(item);

            if (result is null)
                return null;

            List<NutritionalValue> nutritionalValues = await _unitOfWork.NutritionalValues.GetAll();

            Recipe recipe = await _unitOfWork.Recipes.GetById(result.RecipeId);
            Food food = await _unitOfWork.Foods.GetById(recipe.FoodId);
            NutritionalValue nutritionalValue = nutritionalValues.Find(x => x.FoodId == food.Id && x.IsDefault);

            result.RecipeName = food.Name;
            result.RecipePhoto = food.Image;
            result.CookingTime = recipe.CookingTime;
            result.Kcal = nutritionalValue.Kcal;
            result.Proteins = nutritionalValue.Proteins;
            result.Fats = nutritionalValue.Fats;
            result.Carbohydrates = nutritionalValue.Carbohydrates;

            return result;
        }

        public async Task<bool> Update(MenuStringDto entityDto)
        {
            if (!await _unitOfWork.MenuStrings.Exists(entityDto.Id))
                return false;

            MenuString item = await _unitOfWork.MenuStrings.GetById(entityDto.Id);

            item.Id = entityDto.Id;
            item.RecipeId = entityDto.RecipeId;
            item.MealTypeId = entityDto.MealTypeId;
            item.MenuId = entityDto.MenuId;

            await _unitOfWork.MenuStrings.Update(item);
            return await SaveAsync();
        }

        #endregion

        public async Task<List<NutritionalValueDto>> GetDishesNutritionalValues(string menuId)
        {
            List<MenuString> items = await _unitOfWork.MenuStrings.GetAll();

            items = items.Where(x => x.MenuId == menuId).ToList();

            List<NutritionalValue> nutritionalValues = await _unitOfWork.NutritionalValues.GetAll();
            List<NutritionalValueDto> result = [];
            foreach (MenuString item in items)
            {
                Recipe recipe = await _unitOfWork.Recipes.GetById(item.RecipeId);
                Food food = await _unitOfWork.Foods.GetById(recipe.FoodId);
                NutritionalValue nutritionalValue = nutritionalValues.Find(x => x.FoodId == food.Id && x.IsDefault);

                if (nutritionalValue is not null)
                    result.Add(new(nutritionalValue));
            }

            return result;
        }

        public async Task<List<MenuStringDto>> GetMenuDishes(string menuId, string mealTypeId)
        {
            List<MenuString> items = await _unitOfWork.MenuStrings.GetAll();

            List<MenuStringDto> result = items
                .Select(x => new MenuStringDto(x))
                .Where(x => x.MenuId == menuId && x.MealTypeId == mealTypeId)
                .ToList();

            List<NutritionalValue> nutritionalValues = await _unitOfWork.NutritionalValues.GetAll();
            foreach (MenuStringDto item in result)
            {
                Recipe recipe = await _unitOfWork.Recipes.GetById(item.RecipeId);
                Food food = await _unitOfWork.Foods.GetById(recipe.FoodId);
                NutritionalValue nutritionalValue = nutritionalValues.Find(x => x.FoodId == food.Id && x.IsDefault);

                item.RecipeName = food.Name;
                item.RecipePhoto = food.Image;
                item.CookingTime = recipe.CookingTime;
                item.Kcal = nutritionalValue.Kcal;
                item.Proteins = nutritionalValue.Proteins;
                item.Fats = nutritionalValue.Fats;
                item.Carbohydrates = nutritionalValue.Carbohydrates;
            }

            return result;
        }
    }
}
