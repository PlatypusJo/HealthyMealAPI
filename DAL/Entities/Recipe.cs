using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class Recipe
    {
        [Key]
        public string Id { get; set; } = null!;
        public string FoodId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string MealTypeId { get; set; } = null!;
        public TimeSpan CookingTime { get; set; }

        public virtual AppUser AppUser { get; set; } = null!;
        public virtual Food Food { get; set; } = null!;
        public virtual MealType MealType { get; set; } = null!;
        public virtual ICollection<CookingStep> CookingSteps { get; } = new List<CookingStep>();
        public virtual ICollection<MenuString> MenuStrings { get; } = new List<MenuString>();
        public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();
    }
}
