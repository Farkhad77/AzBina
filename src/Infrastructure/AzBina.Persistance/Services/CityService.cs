using AutoMapper;
using AzBina.Application.Abstracts.Repositories;
using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.CategoryDtos;
using AzBina.Application.DTOs.CityDtos;
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

public class CityService : ICityService
{
    ICityRepository _cityRepository;
    IMapper _mapper;
    public CityService(ICityRepository cityRepository,IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }
    public async Task<BaseResponse<string>> AddAsync(CityCreateDto dto)
    {
        var cityDb = await _cityRepository.GetByFiltered(c => c.Name.Trim().ToLower() == dto.Name.Trim().ToLower()).FirstOrDefaultAsync();
        if (cityDb is not null)
        {
            return new BaseResponse<string>("This city already exists", System.Net.HttpStatusCode.BadRequest);
        }
        City city= new()
        {
            Name = dto.Name.Trim(),

        };
        await _cityRepository.AddAsync(city);
        await _cityRepository.SaveChangeAsync();
        return new BaseResponse<string>(System.Net.HttpStatusCode.Created);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        if (city is null)
        {
            return new BaseResponse<string>("City not found", HttpStatusCode.NotFound);
        }
        _cityRepository.Delete(city);
        await _cityRepository.SaveChangeAsync();
        return new BaseResponse<string>("City deleted successfully", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<CityGetDto>>> GetAllAsync()
    {
        var cities = _cityRepository.GetAll();
        if (cities is null)
        {
            return new BaseResponse<List<CityGetDto>>(HttpStatusCode.NotFound);
        }
        var dtoList = new List<CityGetDto>();
        foreach (var city in cities)
        {
            dtoList.Add(new CityGetDto
            {
                Id = city.Id,
                Name = city.Name
            });
        }
        return new BaseResponse<List<CityGetDto>>("Data", dtoList, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<CityGetDto>> GetByIdAsync(Guid id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        if (city is null)
        {
            return new BaseResponse<CityGetDto>(HttpStatusCode.NotFound);
        }
        var dto = new CityGetDto
        {
            Id = city.Id,
            Name = city.Name
        };
        return new BaseResponse<CityGetDto>("Data", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<CityGetDto>> GetByNameAsync(string search)
    {
        var cities = _cityRepository.GetAll();
        var dtoCity = new CityGetDto();
        foreach (var city in cities)
        {
            if (city.Name == search)
            {
                dtoCity.Name = city.Name;
                dtoCity.Id = city.Id;
            }

        }
        if (dtoCity is null)
        {
            return new BaseResponse<CityGetDto>(HttpStatusCode.NotFound);
        }
        return new BaseResponse<CityGetDto>("Data", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<CityGetDto>>> GetByNameSearchAsync(string namePart)
    {
        var cities = await _cityRepository.GetByNameSearchAsync(namePart);
        if (cities == null || !cities.Any())
        {
            return new BaseResponse<List<CityGetDto>>("No cities found with the given name part", HttpStatusCode.NotFound);
        }

        return new BaseResponse<List<CityGetDto>>("Data", _mapper.Map<List<CityGetDto>>(cities), HttpStatusCode.OK);
    }

    public async Task<BaseResponse<CityUpdateDto>> UpdateAsync(CityUpdateDto dto)
    {
        var cityDb = await _cityRepository.GetByIdAsync(dto.Id);
        if (cityDb is not null)
        {
            return new BaseResponse<CityUpdateDto>(HttpStatusCode.NotFound);
        }

        var existedCity = await _cityRepository
            .GetByFiltered(c => c.Name.Trim().ToLower() == dto.Name.Trim().ToLower())
            .FirstOrDefaultAsync();
        if (existedCity is not null)
        {
            return new BaseResponse<CityUpdateDto>("This city already exists", HttpStatusCode.BadRequest);
        }
        cityDb.Name = dto.Name.Trim();



        await _cityRepository.SaveChangeAsync();
        return new BaseResponse<CityUpdateDto>("City updated successfully", dto, HttpStatusCode.OK);
    }
}
