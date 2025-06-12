using System.Net;
using AzBina.Application.Abstracts.Repositories;
using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.CategoryDtos;
using AzBina.Application.Shared;
using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzBina.Persistance.Services;
public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository { get; }
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<BaseResponse<string>> AddAsync(CategoryCreateDto dto)
    {
        var categoryDb = await _categoryRepository.GetByFiltered(c => c.Name.Trim().ToLower() == dto.Name.Trim().ToLower()).FirstOrDefaultAsync();
        if (categoryDb is not null)
        {
            return new BaseResponse<string>("This category already exists",System.Net.HttpStatusCode.BadRequest);
        }
        Category category = new()
        {
            Name = dto.Name.Trim(),
            
        };
        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangeAsync();
        return new BaseResponse<string>(System.Net.HttpStatusCode.Created);
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

    public async Task<BaseResponse<CategoryUpdateDto>> UpdateAsync(CategoryUpdateDto dto)
    {
        var categoryDb = await  _categoryRepository.GetByIdAsync(dto.Id);
        if (categoryDb is not null)
        {
            return new BaseResponse<CategoryUpdateDto>(HttpStatusCode.NotFound);
        }

        var existedCategory = await _categoryRepository
            .GetByFiltered(c => c.Name.Trim().ToLower() == dto.Name.Trim().ToLower())
            .FirstOrDefaultAsync();
        if (existedCategory is not null)
        {
            return new BaseResponse<CategoryUpdateDto>("This category already exists", HttpStatusCode.BadRequest);
        }
        categoryDb.Name = dto.Name.Trim();



        await _categoryRepository.SaveChangeAsync();
        return new BaseResponse<CategoryUpdateDto>("Category updated successfully", dto, HttpStatusCode.OK);
    }
}
