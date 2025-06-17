using AzBina.Application.DTOs.CityDtos;
using AzBina.Application.DTOs.FavoriteDtos;
using AzBina.Application.Shared;

namespace AzBina.Application.Abstracts.Services;

public interface IFavoriteService
{
    Task<BaseResponse<string>> AddAsync(FavoriteCreateDto dto);
    Task<BaseResponse<string>> DeleteAsync(Guid id);
    Task<BaseResponse<FavoriteUpdateDto>> UpdateAsync(FavoriteUpdateDto dto);
    Task<BaseResponse<FavoriteGetDto>> GetByIdAsync(Guid id);
    Task<BaseResponse<FavoriteGetDto>> GetByNameAsync(string search);
    Task<BaseResponse<List<FavoriteGetDto>>> GetAllAsync();
    Task<BaseResponse<List<FavoriteGetDto>>> GetByNameSearchAsync(string namePart);
}
