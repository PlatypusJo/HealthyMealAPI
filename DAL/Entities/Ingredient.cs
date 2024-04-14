using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class Ingredient
    {
        [Key]
        public string Id { get; set; } = null!;
        public string FoodId { get; set; } = null!;
        public string RecipeId { get; set; } = null!;
        public string UnitsId { get; set; } = null!;
        public double UnitsAmount { get; set; }

        public virtual Recipe Recipe { get; set; } = null!;
        public virtual Food Food { get; set; } = null!;
        public virtual Units Units { get; set; } = null!;
    }
}
