using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class Meal
    {
        [Key]
        public string Id { get; set; } = null!;
        public string MealTypeId { get; set; } = null!;
        public string NutritionalValueId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime Date { get; set; }
        public double AmountEaten { get; set; }

        public virtual AppUser AppUser { get; set; } = null!;
        public virtual NutritionalValue NutritionalValue { get; set; } = null!;
        public virtual MealType MealType { get; set; } = null!;
    }
}
