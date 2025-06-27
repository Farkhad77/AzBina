using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.DTOs.CityDtos;

public record class CityGetDto
{
    public string Name { get; set; }
    public Guid Id { get; set; }
}
