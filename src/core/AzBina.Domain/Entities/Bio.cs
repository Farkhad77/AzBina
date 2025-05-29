using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities;

public class Bio : BaseEntity
{
    public string Key { get; set; }
    public string Value { get; set; }
}
