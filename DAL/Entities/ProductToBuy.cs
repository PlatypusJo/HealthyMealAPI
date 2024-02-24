using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class ProductToBuy
    {
        [Key]
        public string Id { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string UnitsId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public double UnitsAmount { get; set; }
        public DateTime Date { get; set; }
        public bool IsBought { get; set; }

        public virtual AppUser AppUser { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Units Units { get; set; } = null!;
    }
}
