using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICookingStepService : ICrud<CookingStepDto>
    {
        /// <summary>
        /// Получить шаги приготовления рецепта.
        /// </summary>
        /// <param name="recipeId"> Идентификатор рецепта. </param>
        /// <returns> Список шагов приготовления. </returns>
        Task<List<CookingStepDto>> GetRecipeSteps(string recipeId);
    }
}
