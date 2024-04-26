using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PhysicalActivityTypeDto
    {
        public PhysicalActivityTypeDto() { }
        public PhysicalActivityTypeDto(PhysicalActivityType physicalActivityType) 
        { 
            Id = physicalActivityType.Id;
            Name = physicalActivityType.Name;
            Description = physicalActivityType.Description;
            ActivityFactor = physicalActivityType.ActivityFactor;
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double ActivityFactor { get; set; }
    }
}
