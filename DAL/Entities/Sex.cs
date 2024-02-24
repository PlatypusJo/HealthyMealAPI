using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class Sex
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<AppUser> Users { get; } = new List<AppUser>();
    }
}
