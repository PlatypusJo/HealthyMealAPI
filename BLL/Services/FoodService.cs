using Azure;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services.Abstract;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FoodService : BaseService, IFoodService
    {
        public FoodService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(FoodDto entityDto)
        {
            Food food = new()
            { 
                Id = entityDto.Id,
                Name = entityDto.Name,
                UserId = entityDto.UserId,
                Image = entityDto.Image,
                Description = entityDto.Description,
            };

            await _unitOfWork.Foods.Create(food);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.Foods.Exists(id))
                return false;

            List<NutritionalValue> nutritionalValues = await _unitOfWork.NutritionalValues.GetAll();
            foreach (NutritionalValue nutritionalValue in nutritionalValues.Where(n => n.FoodId == id).ToList())
            {
                await _unitOfWork.NutritionalValues.Delete(nutritionalValue.Id);
            }

            List<Meal> meals = await _unitOfWork.Meals.GetAll();
            foreach(Meal meal in meals.Where(m => m.FoodId == id).ToList())
            {
                await _unitOfWork.Meals.Delete(meal.Id);
            }

            List<ProductToBuy> products = await _unitOfWork.ProductsToBuy.GetAll();
            foreach (ProductToBuy product in products.Where(p => p.FoodId == id).ToList())
            {
                await _unitOfWork.ProductsToBuy.Delete(product.Id);
            }

            List<Ingredient> ingredients = await _unitOfWork.Ingredients.GetAll();
            foreach (Ingredient ingredient in ingredients.Where(i => i.FoodId == id).ToList())
            {
                await _unitOfWork.Ingredients.Delete(ingredient.Id);
            }

            List<Recipe> recipes = await _unitOfWork.Recipes.GetAll();
            recipes = recipes.Where(r => r.FoodId == id).ToList();

            List<CookingStep> cookingSteps = await _unitOfWork.CookingSteps.GetAll();
            List<MenuString> menuStrings = await _unitOfWork.MenuStrings.GetAll();
            foreach (Recipe recipe in recipes)
            {
                foreach (CookingStep cookingStep in cookingSteps.Where(c => c.RecipeId == recipe.Id).ToList())
                {
                    await _unitOfWork.CookingSteps.Delete(cookingStep.Id);
                }

                foreach (MenuString menuString in menuStrings.Where(m => m.RecipeId == recipe.Id).ToList())
                {
                    await _unitOfWork.MenuStrings.Delete(menuString.Id);
                }

                await _unitOfWork.Recipes.Delete(recipe.Id);
            }

            await _unitOfWork.Foods.Delete(id);

            return await SaveAsync();
        }

        public async Task<bool> Exists(string id) => await _unitOfWork.Foods.Exists(id);

        public async Task<List<FoodDto>> GetAll()
        {
            List<Food> items = await _unitOfWork.Foods.GetAll();

            List<FoodDto> result = items.Select(x => new FoodDto(x)).ToList();

            List<Units> units = await _unitOfWork.Units.GetAll();
            List<NutritionalValue> nutritionalValues = await _unitOfWork.NutritionalValues.GetAll();

            foreach (FoodDto foodDto in result)
            {
                NutritionalValue nutritionalValueDefault = nutritionalValues.Find(x => x.FoodId == foodDto.Id && x.IsDefault);
                Units unitsDefault = units.Find(x => x.Id == nutritionalValueDefault.UnitsId);

                foodDto.DefaultUnitsName = unitsDefault.Name;
                foodDto.DefaultUnitsAmount = nutritionalValueDefault.UnitsAmount;
                foodDto.Kcal = nutritionalValueDefault.Kcal;
                foodDto.Proteins = nutritionalValueDefault.Proteins;
                foodDto.Fats = nutritionalValueDefault.Fats;
                foodDto.Carbohydrates = nutritionalValueDefault.Carbohydrates;
            }

            return result;
        }

        public async Task<FoodDto> GetById(string id)
        {
            Food food = await _unitOfWork.Foods.GetById(id);

            FoodDto? result = food is null ? new FoodDto() : new FoodDto(food);

            List<Units> units = await _unitOfWork.Units.GetAll();
            List<NutritionalValue> nutritionalValues = await _unitOfWork.NutritionalValues.GetAll();

            NutritionalValue nutritionalValueDefault = nutritionalValues.Find(x => x.FoodId == result.Id && x.IsDefault);
            Units unitsDefault = units.Find(x => x.Id == nutritionalValueDefault.UnitsId);

            result.DefaultUnitsName = unitsDefault.Name;
            result.DefaultUnitsAmount = nutritionalValueDefault.UnitsAmount;
            result.Kcal = nutritionalValueDefault.Kcal;
            result.Proteins = nutritionalValueDefault.Proteins;
            result.Fats = nutritionalValueDefault.Fats;
            result.Carbohydrates = nutritionalValueDefault.Carbohydrates;

            return result;
        }

        public async Task<bool> Update(FoodDto entityDto)
        {
            if (!await _unitOfWork.Foods.Exists(entityDto.Id))
                return false;

            Food food = await _unitOfWork.Foods.GetById(entityDto.Id);

            food.Id = entityDto.Id;
            food.Name = entityDto.Name;
            food.UserId = entityDto.UserId;
            food.Image = entityDto.Image;
            food.Description = entityDto.Description;

            await _unitOfWork.Foods.Update(food);
            return await SaveAsync();
        }

        #endregion
        
        public async Task<(List<FoodDto> foods, int countFound)> GetFoodPage(string userId, int pageSize, int curPage, string searchBarText, bool isUserOnly)
        {
            (List<FoodDto> foods, int countFound) result = new();

            searchBarText = Regex.Escape(searchBarText);
            string pattern = $"\\b{searchBarText}\\b";

            // Формирование списка еды без рецептов.
            List<Food> foods = [];
            List<Recipe> recipes = [];
            foods = await _unitOfWork.Foods.GetAll();
            foods = isUserOnly ? foods.Where(f => f.UserId == userId).ToList() : foods.Where(f => f.UserId == userId || f.UserId == "Common").ToList();

            recipes = await _unitOfWork.Recipes.GetAll();
            List<Food> recipesInFood = [];
            for (int i = 0; i < recipes.Count; i++)
            {
                Food food = foods.Find(f => f.Id == recipes[i].FoodId);
                recipesInFood.Add(food);
            }
            foods = foods.Except(recipesInFood).ToList();

            // Отбор элементов с совпадениями по поисковому тексту.
            if (searchBarText != string.Empty)
            {
                foods = foods.Where(f => f.Name.StartsWith(searchBarText, StringComparison.OrdinalIgnoreCase) || Regex.IsMatch(f.Description, pattern, RegexOptions.IgnoreCase)).ToList();
            }

            List<FoodDto> foodDtos = foods.Select(x => new FoodDto(x)).ToList();

            List<Units> units = await _unitOfWork.Units.GetAll();
            List<NutritionalValue> nutritionalValues = await _unitOfWork.NutritionalValues.GetAll();

            foreach (FoodDto foodDto in foodDtos)
            {
                NutritionalValue nutritionalValueDefault = nutritionalValues.Find(x => x.FoodId == foodDto.Id && x.IsDefault);
                Units unitsDefault = units.Find(x => x.Id == nutritionalValueDefault.UnitsId);

                foodDto.DefaultUnitsName = unitsDefault.Name;
                foodDto.DefaultUnitsAmount = nutritionalValueDefault.UnitsAmount;
                foodDto.Kcal = nutritionalValueDefault.Kcal;
                foodDto.Proteins = nutritionalValueDefault.Proteins;
                foodDto.Fats = nutritionalValueDefault.Fats;
                foodDto.Carbohydrates = nutritionalValueDefault.Carbohydrates;
            }

            // Формирование ответа.
            int skipAmount = (curPage - 1) * pageSize;
            result.foods = foodDtos.Skip(skipAmount).Take(pageSize).ToList();
            result.countFound = foodDtos.Count;

            return result;
        }
    }
}
