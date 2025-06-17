using System.Net;
using AutoMapper;
using AzBina.Application.Abstracts.Repositories;
using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.TownshipDtos;
using AzBina.Application.Shared;
using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzBina.Persistance.Services;

public class TownshipService : ITownshipService
{
    private readonly ITownshipRepository _townshipRepository;
    private readonly IMapper _mapper;

    public TownshipService(ITownshipRepository townshipRepository, IMapper mapper)
    {
        _townshipRepository = townshipRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<string>> AddAsync(TownshipCreateDto dto)
    {
        var exists = await _townshipRepository
            .GetByFiltered(t => t.Name.Trim().ToLower() == dto.Name.Trim().ToLower()
                             && t.DistrictId == dto.DistrictId)
            .FirstOrDefaultAsync();

        if (exists is not null)
        {
            return new BaseResponse<string>("This township already exists", HttpStatusCode.BadRequest);
        }

        var township = new Township
        {
            Name = dto.Name.Trim(),
            DistrictId = dto.DistrictId
        };

        await _townshipRepository.AddAsync(township);
        await _townshipRepository.SaveChangeAsync();

        return new BaseResponse<string>("Township successfully created", HttpStatusCode.Created);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id)
    {
        var township = await _townshipRepository.GetByIdAsync(id);
        if (township is null)
        {
            return new BaseResponse<string>("Township not found", HttpStatusCode.NotFound);
        }

        _townshipRepository.Delete(township);
        await _townshipRepository.SaveChangeAsync();

        return new BaseResponse<string>("Township deleted successfully", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<TownshipGetDto>>> GetAllAsync()
    {
        var townships = _townshipRepository.GetAll().ToList();

        if (!townships.Any())
        {
            return new BaseResponse<List<TownshipGetDto>>("No township found", HttpStatusCode.NotFound);
        }

        var dtoList = _mapper.Map<List<TownshipGetDto>>(townships);
        return new BaseResponse<List<TownshipGetDto>>("Data", dtoList, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<TownshipGetDto>> GetByIdAsync(Guid id)
    {
        var township = await _townshipRepository.GetByIdAsync(id);
        if (township is null)
        {
            return new BaseResponse<TownshipGetDto>("Township not found", HttpStatusCode.NotFound);
        }

        var dto = _mapper.Map<TownshipGetDto>(township);
        return new BaseResponse<TownshipGetDto>("Data", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<TownshipGetDto>> GetByNameAsync(string search)
    {
        var township = _townshipRepository
            .GetAll()
            .FirstOrDefault(t => t.Name.Trim().ToLower() == search.Trim().ToLower());

        if (township is null)
        {
            return new BaseResponse<TownshipGetDto>("Township not found", HttpStatusCode.NotFound);
        }

        var dto = _mapper.Map<TownshipGetDto>(township);
        return new BaseResponse<TownshipGetDto>("Data", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<TownshipGetDto>>> GetByNameSearchAsync(string namePart)
    {
        var townships = await _townshipRepository
            .GetByFiltered(t => t.Name.Contains(namePart))
            .ToListAsync();

        if (townships is null || !townships.Any())
        {
            return new BaseResponse<List<TownshipGetDto>>("No townships matched the search", HttpStatusCode.NotFound);
        }

        var dtos = _mapper.Map<List<TownshipGetDto>>(townships);
        return new BaseResponse<List<TownshipGetDto>>("Data", dtos, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<TownshipUpdateDto>> UpdateAsync(TownshipUpdateDto dto)
    {
        var township = await _townshipRepository.GetByIdAsync(dto.DisctrictId); // İd typo duzeldiş lazım ola biler
        if (township is null)
        {
            return new BaseResponse<TownshipUpdateDto>("Township not found", HttpStatusCode.NotFound);
        }

        var alreadyExists = await _townshipRepository
            .GetByFiltered(t => t.Id != dto.DisctrictId &&
                                t.Name.Trim().ToLower() == dto.Name.Trim().ToLower())
            .FirstOrDefaultAsync();

        if (alreadyExists is not null)
        {
            return new BaseResponse<TownshipUpdateDto>("This township name already exists", HttpStatusCode.BadRequest);
        }

        township.Name = dto.Name.Trim();
        township.DistrictId = dto.DisctrictId;

        await _townshipRepository.SaveChangeAsync();
        return new BaseResponse<TownshipUpdateDto>("Township updated successfully", dto, HttpStatusCode.OK);
    }
}
