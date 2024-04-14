using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class NutritionalValue
    {
        [Key]
        public string Id { get; set; } = null!;
        public string FoodId { get; set; } = null!;
        public string UnitsId { get; set; } = null!;
        public double Kcal { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double UnitsAmount { get; set; }
        public bool IsDefault { get; set; }

        public virtual Food Food { get; set; } = null!;
        public virtual Units Units { get; set; } = null!;
    }
}
