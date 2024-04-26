using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductToBuyDto
    {
        public ProductToBuyDto() { }
        public ProductToBuyDto(ProductToBuy productToBuy)
        {
            Id = productToBuy.Id;
            FoodId = productToBuy.FoodId;
            UnitsId = productToBuy.UnitsId;
            UserId = productToBuy.UserId;
            UnitsAmount = productToBuy.UnitsAmount;
            Date = productToBuy.Date;
            IsBought = productToBuy.IsBought;
            UnitsName = productToBuy.Units.Name;
            FoodName = productToBuy.Food.Name;
        }

        public string Id { get; set; } = null!;
        public string FoodId { get; set; } = null!;
        public string UnitsId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string UnitsName { get; set; } = null!;
        public string FoodName { get; set; } = null!;
        public double UnitsAmount { get; set; }
        public DateTime Date { get; set; }
        public bool IsBought { get; set; }
    }
}
