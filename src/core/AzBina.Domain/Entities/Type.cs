using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DependOn { get; set; }

        public ICollection<Ad> Ads { get; set; }
    }

}
