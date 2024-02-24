using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class Menu
    {
        [Key]
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime Date { get; set; }
        public double Kcal { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }

        public virtual AppUser AppUser { get; set; } = null!;
        public virtual ICollection<MenuString> MenuStrings { get; } = new List<MenuString>();
        public virtual ICollection<MenuTemplate> MenuTemplates { get; } = new List<MenuTemplate>();
    }
}
