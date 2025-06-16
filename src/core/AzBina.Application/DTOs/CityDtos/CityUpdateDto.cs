using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.DTOs.CityDtos;                  

public class CityUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!; // City name cannot be null
}
