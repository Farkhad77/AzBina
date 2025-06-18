namespace AzBina.Application.DTOs.CityDtos;                  

public class CityUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!; // City name cannot be null
}
