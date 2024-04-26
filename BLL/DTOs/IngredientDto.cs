using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class IngredientDto
    {
        public IngredientDto() { }
        public IngredientDto(Ingredient ingredient)
        {
            Id = ingredient.Id;
            FoodId = ingredient.FoodId;
            RecipeId = ingredient.RecipeId;
            UnitsId = ingredient.UnitsId;
            UnitsAmount = ingredient.UnitsAmount;
            Name = ingredient.Food.Name;
            UnitsName = ingredient.Units.Name;
        }

        public string Id { get; set; } = null!;
        public string FoodId { get; set; } = null!;
        public string RecipeId { get; set; } = null!;
        public string UnitsId { get; set; } = null!;
        public double UnitsAmount { get; set; }
        public string Name { get; set; } = null!;
        public string UnitsName { get; set; } = null!;
    }
}
