using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RecipeDto : BaseNutritionalValueDto
    {
        public RecipeDto() { }
        public RecipeDto(Recipe recipe) 
        { 
            Id = recipe.Id;
            FoodId = recipe.FoodId;
            UserId = recipe.UserId;
            MealTypeId = recipe.MealTypeId;
            CookingTime = recipe.CookingTime;
        }

        public string Id { get; set; } = null!;
        public string FoodId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string MealTypeId { get; set; } = null!;
        public TimeSpan CookingTime { get; set; }
        public string MealTypeName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public byte[]? Image { get; set; }

    }
}
