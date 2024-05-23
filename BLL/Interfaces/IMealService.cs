using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMealService : ICrud<MealDto>
    {
        /// <summary>
        /// Постраничное получение списка приёмов пищи.
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <param name="mealTypeId"> Идентификатор типа приёма пищи. </param>
        /// <param name="date"> Дата приёма пищи. </param>
        /// <param name="curPage"> Текущая страница. </param>
        /// <param name="pageSize"> Размер страницы. </param>
        /// <returns> Список приёмов пищи для страницы и общее количество найденных приёмов пищи. </returns>
        Task<(List<MealDto> meals, int countFound)> GetMealsPage(string userId, string mealTypeId, DateTime date, int curPage, int pageSize);
    }
}
