using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.DTOs
{
    public class NutritionalValueDto : BaseNutritionalValueDto
    {
        public NutritionalValueDto() { }
        public NutritionalValueDto(NutritionalValue nutritionalValue)
        {
            Id = nutritionalValue.Id;
            FoodId = nutritionalValue.FoodId;
            UnitsId = nutritionalValue.UnitsId;
            UnitsAmount = nutritionalValue.UnitsAmount;
            IsDefault = nutritionalValue.IsDefault;
            Kcal = nutritionalValue.Kcal;
            Proteins = nutritionalValue.Proteins;
            Fats = nutritionalValue.Fats;
            Carbohydrates = nutritionalValue.Carbohydrates;
        }

        public string Id { get; set; } = null!;
        public string FoodId { get; set; } = null!;
        public string UnitsId { get; set; } = null!;
        public double UnitsAmount { get; set; }
        public bool IsDefault { get; set; }
    }
}
