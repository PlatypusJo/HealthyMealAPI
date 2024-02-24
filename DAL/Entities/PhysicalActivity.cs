using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class PhysicalActivity
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Value { get; set; }

        public virtual ICollection<AppUser> Users { get; } = new List<AppUser>();
    }
}
