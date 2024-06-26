﻿using System;
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
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public byte[]? Image { get; set; }
        public string Description { get; set; } = null!;

        public virtual AppUser AppUser { get; set; } = null!;
        public virtual ICollection<NutritionalValue> NutritionalValues { get; } = new List<NutritionalValue>();
        public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();
        public virtual ICollection<ProductToBuy> ProductsToBuy { get; } = new List<ProductToBuy>();
        public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();
        public virtual ICollection<Meal> Meals { get; } = new List<Meal>();
    }
}
