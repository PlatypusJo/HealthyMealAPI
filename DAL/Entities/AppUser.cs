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
        public double KcalGoal { get; set; }
        public double NormalKcal { get; set; }

        public virtual ICollection<Meal> Meals { get; } = new List<Meal>();
    }
}
