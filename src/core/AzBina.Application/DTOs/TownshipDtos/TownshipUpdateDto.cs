namespace AzBina.Application.DTOs.TownshipDtos;

public record class TownshipUpdateDto
{
    public Guid DisctrictId { get; set; } // Unique identifier for the township
    public string Name { get; set; } = null!; // Township name cannot be null
}
