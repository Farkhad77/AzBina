using AzBina.Application.DTOs.TownshipDtos;
using AzBina.Application.Shared;

namespace AzBina.Application.Abstracts.Services;

public interface ITownshipService
{
    Task<BaseResponse<string>> AddAsync(TownshipCreateDto dto);
    Task<BaseResponse<string>> DeleteAsync(Guid id);
    Task<BaseResponse<TownshipUpdateDto>> UpdateAsync(TownshipUpdateDto dto);
    Task<BaseResponse<TownshipGetDto>> GetByIdAsync(Guid id);
    Task<BaseResponse<TownshipGetDto>> GetByNameAsync(string search);
    Task<BaseResponse<List<TownshipGetDto>>> GetAllAsync();
    Task<BaseResponse<List<TownshipGetDto>>> GetByNameSearchAsync(string namePart);
}
