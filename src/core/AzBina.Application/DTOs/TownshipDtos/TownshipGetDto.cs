namespace AzBina.Application.DTOs.TownshipDtos;

public record class TownshipGetDto
{
    public string Name { get; set; } = null!; // Township name cannot be null
}
