namespace AzBina.Application.DTOs.FavoriteDtos;

public record class FavoriteGetDto
{
    public Guid AdId { get; set; }
    public string Name { get; set; } = null!;
}
