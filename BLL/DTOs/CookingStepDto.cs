using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CookingStepDTO
    {
        public CookingStepDTO() { }
        public CookingStepDTO(CookingStep cookingStep) 
        { 
            Id = cookingStep.Id;
            RecipeId = cookingStep.RecipeId;
            StepNumber = cookingStep.StepNumber;
            Description = cookingStep.Description;
        }

        public string Id { get; set; } = null!;
        public string RecipeId { get; set; } = null!;
        public int StepNumber { get; set; }
        public string Description { get; set; } = null!;
    }
}
