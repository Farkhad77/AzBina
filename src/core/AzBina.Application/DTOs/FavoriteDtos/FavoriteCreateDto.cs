namespace AzBina.Application.DTOs.FavoriteDtos;

public class FavoriteCreateDto
{
    public string Name { get; set; } = null!;
    public Guid AdId { get; set; } // Foreign key to the Ad entity, cannot be null
}
