using AzBina.Application.DTOs.CategoryDtos;
using AzBina.Domain.Entities;

namespace AzBina.Application.Abstracts.Services;

public interface ICategoryService
{
    Task AddAsync(CategoryCreateDto dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(CategoryUpdateDto dto);
    Task<CategoryGetDto> GetByIdAsync(int id);
    Task<CategoryGetDto> GetByNameAsync(string search);
    Task<List<CategoryGetDto>> GetAllAsync();
}
