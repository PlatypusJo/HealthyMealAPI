using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MenuDto : BaseNutritionalValueDto
    {
        public MenuDto() { }
        public MenuDto(Menu menu) 
        { 
            Id = menu.Id;
            UserId = menu.UserId;
            Date = menu.Date;
            Kcal = menu.Kcal;
            Proteins = menu.Proteins;
            Fats = menu.Fats;
            Carbohydrates = menu.Carbohydrates;
        }

        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
