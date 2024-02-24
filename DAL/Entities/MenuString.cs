using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class MenuString
    {
        [Key]
        public string Id { get; set; } = null!;
        public string MealTypeId { get; set; } = null!;
        public string RecipeId { get; set; } = null!;
        public string MenuId { get; set; } = null!;

        public virtual Recipe Recipe { get; set; } = null!;
        public virtual Menu Menu { get; set; } = null!;
        public virtual MealType MealType { get; set; } = null!;
    }
}
