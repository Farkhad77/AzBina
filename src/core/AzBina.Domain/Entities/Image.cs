using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
    public class Image:BaseEntity
    {
        public string Image_Url { get; set; }
        public bool is_main { get; set; }

        public Ad Ad { get; set; }
        public Guid AdId { get; set; }
    }
}
