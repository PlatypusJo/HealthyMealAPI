using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class Food
    {
        [Key]
        public string Id { get; set; } = null!;

        public virtual ICollection<NutritionalValue> NutritionalValues { get; } = new List<NutritionalValue>();
        public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();
        public virtual ICollection<Product> Products { get; } = new List<Product>();
    }
}
