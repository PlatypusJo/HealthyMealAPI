using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class CookingStep
    {
        [Key]
        public string Id { get; set; } = null!;
        public string RecipeId { get; set; } = null!;
        public int StepNumber { get; set; }
        public string Description { get; set; } = null!;

        public virtual Recipe Recipe { get; set; } = null!;
    }
}
