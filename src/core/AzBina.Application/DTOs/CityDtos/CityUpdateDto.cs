namespace AzBina.Application.DTOs.CityDtos;                  

public record class CityUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!; // City name cannot be null
}
