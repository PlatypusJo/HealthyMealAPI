using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IIngredientService : ICrud<IngredientDto>
    {
        /// <summary>
        /// Получить ингредиенты рецепта.
        /// </summary>
        /// <param name="recipeId"> Идентификатор рецепта. </param>
        /// <returns> Список ингредиентов. </returns>
        Task<List<IngredientDto>> GetRecipeIngredients(string recipeId);
    }
}
