namespace AzBina.Application.DTOs.TownshipDtos;

public class TownshipCreateDto
{
    public string Name { get; set; } = null!; // Township name cannot be null
    public Guid DistrictId { get; set; } // Foreign key to the District entity, cannot be null
}
