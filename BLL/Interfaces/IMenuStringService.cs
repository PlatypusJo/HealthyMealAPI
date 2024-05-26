using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMenuStringService : ICrud<MenuStringDto>
    {
        /// <summary>
        /// Получить блюда меню.
        /// </summary>
        /// <param name="menuId"> Идентификатор меню. </param>
        /// <param name="mealTypeId"> Идентификатор типа приёма пищи. </param>
        /// <returns> Список блюд меню. </returns>
        Task<List<MenuStringDto>> GetMenuDishes(string menuId, string mealTypeId);

        /// <summary>
        /// Получить пищевые ценности блюд меню.
        /// </summary>
        /// <param name="menuId"> Идентификатор меню. </param>
        /// <returns> Список пищевых ценностей меню. </returns>
        Task<List<NutritionalValueDto>> GetDishesNutritionalValues(string menuId);
    }
}
