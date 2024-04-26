using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FoodDto : BaseNutritionalValueDto
    {
        public FoodDto() { }
        public FoodDto(Food food) 
        { 
            Id = food.Id;
            UserId = food.UserId;
            Name = food.Name;
            Image = food.Image;
            Description = food.Description;

            NutritionalValue nutritionalValue = food.NutritionalValues.First(n => n.IsDefault == true);
            DefaultUnitsAmount = nutritionalValue.UnitsAmount;
            DefaultUnitsName = nutritionalValue.Units.Name;
            Kcal = nutritionalValue.Kcal;
            Proteins = nutritionalValue.Proteins;
            Fats = nutritionalValue.Fats;
            Carbohydrates = nutritionalValue.Carbohydrates;
        }

        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public byte[]? Image { get; set; }
        public string Description { get; set; } = null!;
        public string DefaultUnitsName { get; set; } = null!;
        public double DefaultUnitsAmount { get; set; }
    }
}
