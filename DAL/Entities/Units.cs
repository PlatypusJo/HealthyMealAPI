﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class Units
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<NutritionalValue> NutritionalValues { get; } = new List<NutritionalValue>();
        public virtual ICollection<Meal> Meals { get; } = new List<Meal>();
        public virtual ICollection<ProductToBuy> ProductsToBuy { get; } = new List<ProductToBuy>();
        public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();
    }
}
