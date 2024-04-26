using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MenuStringDto : BaseNutritionalValueDto
    {
        public MenuStringDto() { }
        public MenuStringDto(MenuString menuString)
        {
            Id = menuString.Id;
            MealTypeId = menuString.MealTypeId;
            RecipeId = menuString.RecipeId;
            MenuId = menuString.MenuId;
        }

        public string Id { get; set; } = null!;
        public string MealTypeId { get; set; } = null!;
        public string RecipeId { get; set; } = null!;
        public string MenuId { get; set; } = null!;
        public string RecipeName { get; set; } = null!;
        public byte[]? RecipePhoto { get; set; }
        public TimeSpan CookingTime { get; set; }
    }
}
