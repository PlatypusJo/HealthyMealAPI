using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class MealType
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public byte[]? Icon { get; set; }

        public virtual ICollection<Meal> Meals { get; } = new List<Meal>();
        public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();
        public virtual ICollection<MenuString> MenuStrings { get; } = new List<MenuString>();
    }
}
