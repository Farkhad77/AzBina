﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities;

public class Favorite : BaseEntity
{
    public Guid AdId { get; set; }
    public Ad Ad { get; set; }
    
}
