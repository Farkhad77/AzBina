﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int AdsId { get; set; }
        public bool IsMain { get; set; }

        public Ad Ad { get; set; }
    }

}
