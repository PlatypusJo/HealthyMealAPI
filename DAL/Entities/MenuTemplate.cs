using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class MenuTemplate
    {
        [Key]
        public string Id { get; set; } = null!;
        public string MenuId { get; set; } = null!;
        public string Name { get; set; } = null!;

        public Menu Menu { get; set; } = null!;
    }
}
