﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Ad> Ads { get; set; }
}
