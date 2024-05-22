using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFoodService : ICrud<FoodDto>
    {
        /// <summary>
        /// Постраничное получение списка еды.
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <param name="pageSize"> Размер страницы. </param>
        /// <param name="curPage"> Текущая страница. </param>
        /// <param name="searchBarText"> Текст в поисковой строке. </param>
        /// <param name="isUserOnly"> Признак страницы только пользовательских продуктов. </param>
        /// <returns> Список еды для страницы и общее количество найденной еды. </returns>
        Task<(List<FoodDto> foods, int countFound)> GetFoodPage(string userId, int pageSize, int curPage, string searchBarText, bool isUserOnly);
    }
}
