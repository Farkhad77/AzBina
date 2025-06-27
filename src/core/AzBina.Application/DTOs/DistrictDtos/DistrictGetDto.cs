using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.DTOs.DistrictDtos;

public record class DistrictGetDto
{
    public string Name { get; set; }
    public Guid Id { get; set; }
}
