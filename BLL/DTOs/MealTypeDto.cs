using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MealTypeDto
    {
        public MealTypeDto() { }
        public MealTypeDto(MealType mealType) 
        { 
            Id = mealType.Id;
            Name = mealType.Name;   
            Icon = mealType.Icon;
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public byte[]? Icon { get; set; }
    }
}
