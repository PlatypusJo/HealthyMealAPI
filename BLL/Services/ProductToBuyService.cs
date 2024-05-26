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
    public class ProductToBuyService : BaseService, IProductToBuyService
    {
        public ProductToBuyService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(ProductToBuyDto entityDto)
        {
            ProductToBuy item = new()
            {
                Id = entityDto.Id,
                UserId = entityDto.UserId,
                FoodId = entityDto.FoodId,
                UnitsId = entityDto.UnitsId,
                UnitsAmount = entityDto.UnitsAmount,
                Date = entityDto.Date,
                IsBought = entityDto.IsBought,
            };

            await _unitOfWork.ProductsToBuy.Create(item);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.ProductsToBuy.Exists(id))
                return false;

            await _unitOfWork.ProductsToBuy.Delete(id);

            return await SaveAsync();
        }

        public async Task<bool> Exists(string id) => await _unitOfWork.ProductsToBuy.Exists(id);

        public async Task<List<ProductToBuyDto>> GetAll()
        {
            List<ProductToBuy> items = await _unitOfWork.ProductsToBuy.GetAll();

            List<ProductToBuyDto> result = items.Select(x => new ProductToBuyDto(x)).ToList();

            foreach (ProductToBuyDto item in result)
            {
                Food food = await _unitOfWork.Foods.GetById(item.FoodId);
                Units units = await _unitOfWork.Units.GetById(item.UnitsId);

                item.FoodName = food.Name;
                item.UnitsName = units.Name;
            }

            return result;
        }

        public async Task<ProductToBuyDto> GetById(string id)
        {
            ProductToBuy item = await _unitOfWork.ProductsToBuy.GetById(id);

            ProductToBuyDto result = item is null ? null : new ProductToBuyDto(item);

            if (result is null)
                return null;

            Food food = await _unitOfWork.Foods.GetById(result.FoodId);
            Units units = await _unitOfWork.Units.GetById(result.UnitsId);

            result.FoodName = food.Name;
            result.UnitsName = units.Name;

            return result;
        }

        public async Task<bool> Update(ProductToBuyDto entityDto)
        {
            if (!await _unitOfWork.ProductsToBuy.Exists(entityDto.Id))
                return false;

            ProductToBuy item = await _unitOfWork.ProductsToBuy.GetById(entityDto.Id);

            item.Id = entityDto.Id;
            item.UserId = entityDto.UserId;
            item.FoodId = entityDto.FoodId;
            item.UnitsId = entityDto.UnitsId;
            item.UnitsAmount = entityDto.UnitsAmount;
            item.Date = entityDto.Date;
            item.IsBought = entityDto.IsBought;

            await _unitOfWork.ProductsToBuy.Update(item);
            return await SaveAsync();
        }

        #endregion
        
        public async Task<(List<ProductToBuyDto> products, int countFound)> GetShoppingListPage(string userId, DateTime date, int curPage, int pageSize)
        {
            (List<ProductToBuyDto> products, int countFound) result = new();

            List<ProductToBuy> products = await _unitOfWork.ProductsToBuy.GetAll();

            // Отбор элементов с совпадениями по дате
            List<ProductToBuyDto> productDtos = products
                .Select(m => new ProductToBuyDto(m))
                .Where(m => m.UserId == userId && m.Date == date)
                .ToList();

            foreach (ProductToBuyDto item in productDtos)
            {
                Units units = await _unitOfWork.Units.GetById(item.UnitsId);
                Food food = await _unitOfWork.Foods.GetById(item.FoodId);

                item.FoodName = food.Name;
                item.UnitsName = units.Name;
            }

            // Формирование ответа.
            int skipAmount = (curPage - 1) * pageSize;
            result.products = productDtos.Skip(skipAmount).Take(pageSize).ToList();
            result.countFound = productDtos.Count;

            return result;
        }
    }
}
