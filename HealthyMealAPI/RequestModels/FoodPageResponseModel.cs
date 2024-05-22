using BLL.DTOs;

namespace HealthyMealAPI.RequestModels
{
    public class FoodPageResponseModel
    {
        public List<FoodDto> Foods { get; set; } = [];
        public int Count { get; set; }
    }
}
