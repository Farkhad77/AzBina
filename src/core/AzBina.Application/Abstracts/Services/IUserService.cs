using AzBina.Application.DTOs.UserDtos;
using AzBina.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.Abstracts.Services;

public interface IUserService
{
    Task <BaseResponse<string>> Register(UserRegisterDto dto);
    Task<BaseResponse<TokenResponse>> Login(UserLoginDto dto);
    Task<BaseResponse<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request);
    Task<BaseResponse<string>> AddRole(UserAddRoleDto dto); 
}
