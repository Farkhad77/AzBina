using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
    public class Township
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }

        public District District { get; set; }
        public ICollection<Ad> Ads { get; set; }
    }

}
