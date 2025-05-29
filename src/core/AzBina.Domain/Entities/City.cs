using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<District> Districts { get; set; }
        public ICollection<Ad> Ads { get; set; }
    }

}
