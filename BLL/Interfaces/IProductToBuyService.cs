using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductToBuyService : ICrud<ProductToBuyDto>
    {
        /// <summary>
        /// Получить страницу списка покупок.
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <param name="date"> Дата. </param>
        /// <param name="curPage"> Номер текущей страницы. </param>
        /// <param name="pageSize"> Кол-во элементов на странице. </param>
        /// <returns> Список продуктов на странице списка покупок и общее кол-во найденных продуктов. </returns>
        Task<(List<ProductToBuyDto> products, int countFound)> GetShoppingListPage(string userId, DateTime date, int curPage, int pageSize);
    }
}
