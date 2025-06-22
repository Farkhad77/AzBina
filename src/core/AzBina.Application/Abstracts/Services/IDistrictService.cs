using AzBina.Application.DTOs.DistrictDtos;
using AzBina.Application.DTOs.FavoriteDtos;
using AzBina.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.Abstracts.Services;

public interface IDistrictService
{
    Task<BaseResponse<string>> AddAsync(DistrictCreateDto dto);
    Task<BaseResponse<string>> DeleteAsync(Guid id);
    Task<BaseResponse<DistrictUpdateDto>> UpdateAsync(DistrictUpdateDto dto);
    Task<BaseResponse<DistrictGetDto>> GetByIdAsync(Guid id);
    Task<BaseResponse<DistrictGetDto>> GetByNameAsync(string search);
    Task<BaseResponse<List<DistrictGetDto>>> GetAllAsync();
    Task<BaseResponse<List<DistrictGetDto>>> GetByNameSearchAsync(string namePart);
}
