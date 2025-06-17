using System.Net;
using AutoMapper;
using AzBina.Application.Abstracts.Repositories;
using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.FavoriteDtos;
using AzBina.Application.Shared;
using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzBina.Persistance.Services;

public class FavoriteService : IFavoriteService
{
    IFavoriteRepository _favoriteRepository;
    IMapper _mapper;
    public async Task<BaseResponse<string>> AddAsync(FavoriteCreateDto dto)
    {
        var exists = await _favoriteRepository
            .GetByFiltered(f => f.AdId == dto.AdId)
            .FirstOrDefaultAsync();

        if (exists is not null)
        {
            return new BaseResponse<string>("Bu elan artıq favorilərdədir", HttpStatusCode.BadRequest);
        }

        var entity = _mapper.Map<Favorite>(dto);
        await _favoriteRepository.AddAsync(entity);
        await _favoriteRepository.SaveChangeAsync();

        return new BaseResponse<string>("Favoriyə əlavə olundu", HttpStatusCode.Created);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id)
    {
        var favorite = await _favoriteRepository.GetByIdAsync(id);
        if (favorite is null)
        {
            return new BaseResponse<string>("Favori tapılmadı", HttpStatusCode.NotFound);
        }

        _favoriteRepository.Delete(favorite);
        await _favoriteRepository.SaveChangeAsync();

        return new BaseResponse<string>("Favori silindi", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<FavoriteGetDto>>> GetAllAsync()
    {
        var favorites = _favoriteRepository.GetAll().ToList();
        if (!favorites.Any())
        {
            return new BaseResponse<List<FavoriteGetDto>>("Favorilər tapılmadı", HttpStatusCode.NotFound);
        }

        var dtos = _mapper.Map<List<FavoriteGetDto>>(favorites);
        return new BaseResponse<List<FavoriteGetDto>>("Data", dtos, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<FavoriteGetDto>> GetByIdAsync(Guid id)
    {
        var favorite = await _favoriteRepository.GetByIdAsync(id);
        if (favorite is null)
        {
            return new BaseResponse<FavoriteGetDto>("Favori tapılmadı", HttpStatusCode.NotFound);
        }

        var dto = _mapper.Map<FavoriteGetDto>(favorite);
        return new BaseResponse<FavoriteGetDto>("Data", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<FavoriteGetDto>> GetByNameAsync(string search)
    {
        // Ad yoxdur deyə bu method lazımsızdır
        return new BaseResponse<FavoriteGetDto>("Favori adı yoxdur", HttpStatusCode.BadRequest);
    }

    public async Task<BaseResponse<List<FavoriteGetDto>>> GetByNameSearchAsync(string namePart)
    {
        // Name ilə search mümkün deyil
        return new BaseResponse<List<FavoriteGetDto>>("Ad ilə axtarış dəstəklənmir", HttpStatusCode.BadRequest);
    }

    public async Task<BaseResponse<FavoriteUpdateDto>> UpdateAsync(FavoriteUpdateDto dto)
    {
        var favorite = await _favoriteRepository.GetByIdAsync(dto.AdId);
        if (favorite is null)
        {
            return new BaseResponse<FavoriteUpdateDto>("Favori tapılmadı", HttpStatusCode.NotFound);
        }

        // Əgər dəyişmək icazəlidirsə:
        favorite.AdId = dto.AdId;

        await _favoriteRepository.SaveChangeAsync();

        return new BaseResponse<FavoriteUpdateDto>("Favori yeniləndi", dto, HttpStatusCode.OK);
    }
}
