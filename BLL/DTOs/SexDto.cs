using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SexDTO
    {
        public SexDTO() { }
        public SexDTO(Sex sex) 
        { 
            Id = sex.Id;
            Name = sex.Name;
            Coeff = sex.Coeff;
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Coeff { get; set; }
    }
}
