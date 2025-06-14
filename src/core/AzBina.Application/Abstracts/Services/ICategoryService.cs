using AzBina.Application.DTOs.CategoryDtos;
using AzBina.Application.Shared;
using AzBina.Domain.Entities;

namespace AzBina.Application.Abstracts.Services;

public interface ICategoryService
{
    Task <BaseResponse<string>> AddAsync(CategoryCreateDto dto);
    Task <BaseResponse<string>> DeleteAsync(Guid id);
    Task<BaseResponse<CategoryUpdateDto>> UpdateAsync(CategoryUpdateDto dto);
    Task<BaseResponse<CategoryGetDto>> GetByIdAsync(Guid id);
    Task<BaseResponse<CategoryGetDto>> GetByNameAsync(string search);
    Task<BaseResponse<List<CategoryGetDto>>> GetAllAsync();
}
