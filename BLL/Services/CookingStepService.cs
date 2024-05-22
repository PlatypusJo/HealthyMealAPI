using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services.Abstract;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CookingStepService : BaseService, ICookingStepService
    {
        public CookingStepService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(CookingStepDto entityDto)
        {
            CookingStep item = new()
            {
                Id = entityDto.Id,
                RecipeId = entityDto.RecipeId,
                StepNumber = entityDto.StepNumber,
                Description = entityDto.Description,
            };

            await _unitOfWork.CookingSteps.Create(item);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.Sexes.Exists(id))
                return false;

            await _unitOfWork.CookingSteps.Delete(id);

            return await SaveAsync();
        }

        public async Task<bool> Exists(string id) => await _unitOfWork.CookingSteps.Exists(id);

        public async Task<List<CookingStepDto>> GetAll()
        {
            List<CookingStep> items = await _unitOfWork.CookingSteps.GetAll();

            List<CookingStepDto> result = items.Select(x => new CookingStepDto(x)).ToList();

            return result;
        }

        public async Task<CookingStepDto> GetById(string id)
        {
            CookingStep item = await _unitOfWork.CookingSteps.GetById(id);

            return item is null ? null : new(item);
        }

        public async Task<bool> Update(CookingStepDto entityDto)
        {
            if (!await _unitOfWork.CookingSteps.Exists(entityDto.Id))
                return false;

            CookingStep item = await _unitOfWork.CookingSteps.GetById(entityDto.Id);

            item.Id = entityDto.Id;
            item.RecipeId = entityDto.RecipeId;
            item.StepNumber = entityDto.StepNumber;
            item.Description = entityDto.Description;

            await _unitOfWork.CookingSteps.Update(item);
            return await SaveAsync();
        }

        #endregion

        public async Task<List<CookingStepDto>> GetRecipeSteps(string recipeId)
        {
            List<CookingStep> items = await _unitOfWork.CookingSteps.GetAll();

            List<CookingStepDto> result = items
                .Select(x => new CookingStepDto(x))
                .Where(x => x.RecipeId == recipeId)
                .ToList();

            return result;
        }
    }
}
