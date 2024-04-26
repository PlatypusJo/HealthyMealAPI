using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.DTOs
{
    public class MealDto
    {
        public MealDto() { }
        public MealDto(Meal meal) 
        {
            Id = meal.Id;
            MealTypeId = meal.MealTypeId;
            UnitsId = meal.UnitsId;
            FoodId = meal.FoodId;
            UserId = meal.UserId;
            Date = meal.Date;
            AmountEaten = meal.AmountEaten;
            UnitsName = meal.Units.Name;
            FoodName = meal.Food.Name;
        }

        public string Id { get; set; } = null!;
        public string MealTypeId { get; set; } = null!;
        public string UnitsId { get; set; } = null!;
        public string FoodId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime Date { get; set; }
        public double AmountEaten { get; set; }
        public string UnitsName { get; set; } = null!;
        public string FoodName { get; set; } = null!;
    }
}
