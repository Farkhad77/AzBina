using AzBina.Application.Abstracts.Repositories;
using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.CategoryDtos;

namespace AzBina.Persistance.Services;
public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository { get; }
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task AddAsync(CategoryCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CategoryGetDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryGetDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryGetDto> GetByNameAsync(string search)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
