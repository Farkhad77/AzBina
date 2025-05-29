using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
    public class District : BaseEntity
    {
        public string Name { get; set; } = null!;
        public City City { get; set; } = null!;
        public Guid CityId { get; set; }
        public ICollection<Township> Towns { get; set; }
        public ICollection<Ad> Ads
        {
            get; set;
        }
    }
}
