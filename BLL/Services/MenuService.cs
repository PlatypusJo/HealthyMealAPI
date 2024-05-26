using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services.Abstract;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(MenuDto entityDto)
        {
            Menu item = new()
            {
                Id = entityDto.Id,
                UserId = entityDto.UserId,
                Date = entityDto.Date,
                Kcal = entityDto.Kcal,
                Proteins = entityDto.Proteins,
                Fats = entityDto.Fats,
                Carbohydrates = entityDto.Carbohydrates,
            };

            await _unitOfWork.Menus.Create(item);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.Menus.Exists(id))
                return false;

            await _unitOfWork.Menus.Delete(id);

            return await SaveAsync();
        }

        public async Task<bool> Exists(string id) => await _unitOfWork.Menus.Exists(id);

        public async Task<List<MenuDto>> GetAll()
        {
            List<Menu> items = await _unitOfWork.Menus.GetAll();

            List<MenuDto> result = items.Select(x => new MenuDto(x)).ToList();

            return result;
        }

        public async Task<MenuDto> GetById(string id)
        {
            Menu item = await _unitOfWork.Menus.GetById(id);

            return item is null ? null : new(item);
        }

        public async Task<bool> Update(MenuDto entityDto)
        {
            if (!await _unitOfWork.Menus.Exists(entityDto.Id))
                return false;

            Menu item = await _unitOfWork.Menus.GetById(entityDto.Id);

            item.Id = entityDto.Id;
            item.UserId = entityDto.UserId;
            item.Date = entityDto.Date;
            item.Kcal = entityDto.Kcal;
            item.Proteins = entityDto.Proteins;
            item.Fats = entityDto.Fats;
            item.Carbohydrates = entityDto.Carbohydrates;

            await _unitOfWork.Menus.Update(item);
            return await SaveAsync();
        }

        #endregion
        
        public async Task<MenuDto> GetByDate(DateTime date)
        {
            List<Menu> items = await _unitOfWork.Menus.GetAll();

            Menu item = items.Find(x => x.Date == date);

            return item is null ? null : new(item);
        }

    }
}
