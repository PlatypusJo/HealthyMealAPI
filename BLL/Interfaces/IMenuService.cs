using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMenuService : ICrud<MenuDto>
    {
        /// <summary>
        /// Получить меню по дате.
        /// </summary>
        /// <param name="date"> Дата. </param>
        /// <returns> Меню. </returns>
        Task<MenuDto> GetByDate(DateTime date);
    }
}
