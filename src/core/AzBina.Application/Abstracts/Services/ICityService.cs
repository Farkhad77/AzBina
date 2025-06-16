using AzBina.Application.DTOs.CategoryDtos;
using AzBina.Application.DTOs.CityDtos;
using AzBina.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.Abstracts.Services;

public interface ICityService
{
    Task<BaseResponse<string>> AddAsync(CityCreateDto dto);
    Task<BaseResponse<string>> DeleteAsync(Guid id);
    Task<BaseResponse<CityUpdateDto>> UpdateAsync(CityUpdateDto dto);
    Task<BaseResponse<CityGetDto>> GetByIdAsync(Guid id);
    Task<BaseResponse<CityGetDto>> GetByNameAsync(string search);
    Task<BaseResponse<List<CityGetDto>>> GetAllAsync();
    Task<BaseResponse<List<CityGetDto>>> GetByNameSearchAsync(string namePart);
    
}

