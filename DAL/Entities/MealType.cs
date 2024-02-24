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

        public virtual ICollection<Meal> Meals { get; } = new List<Meal>();
    }
}
