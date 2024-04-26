using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UnitsDto
    {
        public UnitsDto() { }
        public UnitsDto(Units units) 
        { 
            Id = units.Id;
            Name = units.Name;
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
