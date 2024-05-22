using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services.Abstract;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SexService : BaseService, ISexService
    {
        public SexService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region ICrud implementation

        public async Task<bool> Create(SexDto entityDto)
        {
            Sex sex = new()
            {
                Id = entityDto.Id,
                Name = entityDto.Name,
                Coeff = entityDto.Coeff,
            };

            await _unitOfWork.Sexes.Create(sex);
            return await SaveAsync();
        }

        public async Task<bool> Delete(string id)
        {
            if (!await _unitOfWork.Sexes.Exists(id))            
                return false;
            
            // Удаление основных сущностей запрещено.

            return false;
        }

        public Task<bool> Exists(string id) => _unitOfWork.Sexes.Exists(id);

        public async Task<List<SexDto>> GetAll()
        {
            List<Sex> items = await _unitOfWork.Sexes.GetAll();

            List<SexDto> result = items.Select(x => new SexDto(x)).ToList();

            return result;
        }

        public async Task<SexDto> GetById(string id)
        {
            Sex item = await _unitOfWork.Sexes.GetById(id);

            return item is null ? null : new(item);
        }

        public async Task<bool> Update(SexDto entityDto)
        {
            if (!await _unitOfWork.Sexes.Exists(entityDto.Id))
                return false;

            Sex sex = await _unitOfWork.Sexes.GetById(entityDto.Id);

            sex.Id = entityDto.Id;
            sex.Name = entityDto.Name;
            sex.Coeff = entityDto.Coeff;

            await _unitOfWork.Sexes.Update(sex);
            return await SaveAsync();
        }

        #endregion
        
    }
}
