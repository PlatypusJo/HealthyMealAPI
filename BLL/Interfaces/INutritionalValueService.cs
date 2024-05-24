using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INutritionalValueService : ICrud<NutritionalValueDto>
    {
        /// <summary>
        /// Получить пищевую ценность еды.
        /// </summary>
        /// <param name="foodId"> Идентификатор еды. </param>
        /// <param name="unitsId"> Идентификатор единицы измерения. </param>
        /// <returns> Пищевая ценность. </returns>
        Task<NutritionalValueDto> GetFoodNutritionalValue(string foodId, string unitsId);
    }
}
