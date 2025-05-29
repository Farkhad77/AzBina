using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
    public class Township:BaseEntity
    {
        public string Name { get; set; } = null!;
        public District District { get; set; } = null!;
        public Guid DistrictId { get; set; }

        public ICollection<Ad> Ads { get; set; }
    }

}
