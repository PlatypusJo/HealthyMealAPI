using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class AppUser : IdentityUser
    {
        public double KcalAmountGoal { get; set; }
        public double NormalKcalAmount { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string SexId { get; set; } = null!;
        public string PhysicalActivityId { get; set; } = null!;

        public virtual Sex Sex { get; set; } = null!;
        public virtual PhysicalActivityType PhysicalActivity { get; set; } = null!;
        public virtual ICollection<Meal> Meals { get; } = new List<Meal>();
        public virtual ICollection<Product> Products { get; } = new List<Product>();
        public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();
        public virtual ICollection<ProductToBuy> ProductsToBuy { get; } = new List<ProductToBuy>();
        public virtual ICollection<Menu> Menus { get; } = new List<Menu>();
    }
}
