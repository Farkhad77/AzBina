﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AdsId { get; set; }

        public User User { get; set; }
        public Ad Ad { get; set; }
    }

}
