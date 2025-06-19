using AutoMapper;
using AzBina.Application.Abstracts.Repositories;
using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.DistrictDtos;
using AzBina.Application.Shared;
using AzBina.Domain.Entities;
using AzBina.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Persistance.Services;

public class DistrictService : IDistrictService
{
    IDistrictRepository _districtRepository;
    IMapper _mapper;
    public DistrictService(IDistrictRepository districtRepository, IMapper mapper)
    {
        _districtRepository = districtRepository;
        _mapper = mapper;
    }
    public async Task<BaseResponse<string>> AddAsync(DistrictCreateDto dto)
    {
        var districtDb = await _districtRepository.GetByFiltered(d => d.Name.Trim().ToLower() == dto.Name.Trim().ToLower()).FirstOrDefaultAsync();
        if (districtDb is not null)
        {
            return new BaseResponse<string>("This district already exists", System.Net.HttpStatusCode.BadRequest);
        }
        District district = new()
        {
            Name = dto.Name.Trim(),
        };
        await _districtRepository.AddAsync(district);
        await _districtRepository.SaveChangeAsync();
        return new BaseResponse<string>(System.Net.HttpStatusCode.Created);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id)
    {
        var district = await _districtRepository.GetByIdAsync(id);
        if (district is null)
        {
            return new BaseResponse<string>("District not found", HttpStatusCode.NotFound);
        }
        _districtRepository.Delete(district);
        await _districtRepository.SaveChangeAsync();
        return new BaseResponse<string>("District deleted successfully", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<DistrictGetDto>>> GetAllAsync()
    {
        var districts = _districtRepository.GetAll();
        if (districts is null)
        {
            return new BaseResponse<List<DistrictGetDto>>(HttpStatusCode.NotFound);
        }
        var dtoList = new List<DistrictGetDto>();
        foreach (var district in districts)
        {
            dtoList.Add(new DistrictGetDto
            {
                Id = district.Id,
                Name = district.Name
            });
        }
        return new BaseResponse<List<DistrictGetDto>>("Data", dtoList, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<DistrictGetDto>> GetByIdAsync(Guid id)
    {

        var district = await _districtRepository.GetByIdAsync(id);
        if (district is null)
        {
            return new BaseResponse<DistrictGetDto>(HttpStatusCode.NotFound);
        }
        var dto = new DistrictGetDto
        {
            Id = district.Id,
            Name = district.Name
        };
        return new BaseResponse<DistrictGetDto>("Data", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<DistrictGetDto>> GetByNameAsync(string search)
    {
        var districts = _districtRepository.GetAll();
        var dtoDistrict = new DistrictGetDto();
        foreach (var district in districts)
        {
            if (district.Name == search)
            {
                dtoDistrict.Name = district.Name;
                dtoDistrict.Id = district.Id;
            }
        }
        if (dtoDistrict is null)
        {
            return new BaseResponse<DistrictGetDto>(HttpStatusCode.NotFound);
        }
        return new BaseResponse<DistrictGetDto>("Data", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<DistrictGetDto>>> GetByNameSearchAsync(string namePart)
    {
        var districts = await _districtRepository.GetByNameSearchAsync(namePart);
        if (districts == null || !districts.Any())
        {
            return new BaseResponse<List<DistrictGetDto>>("No districts found with the given name part", HttpStatusCode.NotFound);
        }

        return new BaseResponse<List<DistrictGetDto>>("Data", _mapper.Map<List<DistrictGetDto>>(districts), HttpStatusCode.OK);
    }

    public async Task<BaseResponse<DistrictUpdateDto>> UpdateAsync(DistrictUpdateDto dto)
    {
        var districtDb = await _districtRepository.GetByIdAsync(dto.Id);
        if (districtDb is null)
        {
            return new BaseResponse<DistrictUpdateDto>(HttpStatusCode.NotFound);
        }

        var existedDistrict = await _districtRepository
            .GetByFiltered(d => d.Name.Trim().ToLower() == dto.Name.Trim().ToLower())
            .FirstOrDefaultAsync();
        if (existedDistrict is not null)
        {
            return new BaseResponse<DistrictUpdateDto>("This district already exists", HttpStatusCode.BadRequest);
        }

        districtDb.Name = dto.Name.Trim();

        await _districtRepository.SaveChangeAsync();
        return new BaseResponse<DistrictUpdateDto>("District updated successfully", dto, HttpStatusCode.OK);
    }
}

    
