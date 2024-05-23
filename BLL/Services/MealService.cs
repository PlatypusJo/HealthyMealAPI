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
    public class MealService : BaseService, IMealService
    {
        public MealService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(MealDto entityDto)
        {
            Meal item = new()
            {
                Id = entityDto.Id,
                MealTypeId = entityDto.MealTypeId,
                UserId = entityDto.UserId,
                UnitsId = entityDto.UnitsId,
                FoodId = entityDto.FoodId,
                Date = entityDto.Date,
                AmountEaten = entityDto.AmountEaten,
            };

            await _unitOfWork.Meals.Create(item);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.Meals.Exists(id))
                return false;

            await _unitOfWork.Meals.Delete(id);

            return await SaveAsync();
        }

        public async Task<bool> Exists(string id) => await _unitOfWork.Meals.Exists(id);

        public async Task<List<MealDto>> GetAll()
        {
            List<Meal> items = await _unitOfWork.Meals.GetAll();

            List<MealDto> result = items.Select(x => new MealDto(x)).ToList();

            foreach (MealDto item in result)
            {
                Units units = await _unitOfWork.Units.GetById(item.UnitsId);
                Food food = await _unitOfWork.Foods.GetById(item.FoodId);

                item.FoodName = food.Name;
                item.UnitsName = units.Name;
            }

            return result;
        }

        public async Task<MealDto> GetById(string id)
        {
            Meal item = await _unitOfWork.Meals.GetById(id);

            if (item is null)
                return null;

            MealDto result = new(item);

            Units units = await _unitOfWork.Units.GetById(result.UnitsId);
            Food food = await _unitOfWork.Foods.GetById(result.FoodId);

            result.FoodName = food.Name;
            result.UnitsName = units.Name;

            return result;
        }

        public async Task<bool> Update(MealDto entityDto)
        {
            if (!await _unitOfWork.Meals.Exists(entityDto.Id))
                return false;

            Meal item = await _unitOfWork.Meals.GetById(entityDto.Id);

            item.Id = entityDto.Id;
            item.MealTypeId = entityDto.MealTypeId;
            item.UnitsId = entityDto.UnitsId;
            item.FoodId = entityDto.FoodId;
            item.UserId = entityDto.UserId;
            item.Date = entityDto.Date;
            item.AmountEaten = entityDto.AmountEaten;

            await _unitOfWork.Meals.Update(item);
            return await SaveAsync();
        }

        #endregion

        public async Task<(List<MealDto> meals, int countFound)> GetMealsPage(string userId, string mealTypeId, DateTime date, int curPage, int pageSize)
        {
            (List<MealDto> meals, int countFound) result = new();

            List<Meal> meals = await _unitOfWork.Meals.GetAll();

            // Отбор элементов с совпадениями по дате
            List<MealDto> mealDtos = meals
                .Select(m => new MealDto(m))
                .Where(m => m.UserId == userId && m.MealTypeId == mealTypeId && m.Date == date)
                .ToList();

            foreach (MealDto item in mealDtos)
            {
                Units units = await _unitOfWork.Units.GetById(item.UnitsId);
                Food food = await _unitOfWork.Foods.GetById(item.FoodId);

                item.FoodName = food.Name;
                item.UnitsName = units.Name;
            }

            // Формирование ответа.
            int skipAmount = (curPage - 1) * pageSize;
            result.meals = mealDtos.Skip(skipAmount).Take(pageSize).ToList();
            result.countFound = mealDtos.Count;

            return result;
        }
    }
}
