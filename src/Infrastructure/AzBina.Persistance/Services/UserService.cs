using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.UserDtos;
using AzBina.Application.Shared;
using AzBina.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Persistance.Services;

public class UserService : IUserService
{
    private UserManager<AppUser> _userManager { get; }
    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<BaseResponse<string>> Register(UserRegisterDto dto)
    {
        var existedEmail = await _userManager.FindByEmailAsync(dto.Email);
        if (existedEmail is not null)
        {
           return new BaseResponse<string>("This account already exists", System.Net.HttpStatusCode.BadRequest);

        }
        AppUser newUser = new AppUser
        {
            Fullname = dto.Fullname,
            Email = dto.Email,
            UserName = dto.Email
        };
        IdentityResult identityResult = await _userManager.CreateAsync(newUser, dto.Password);
        if (!identityResult.Succeeded)
        {
            var errors = identityResult.Errors;
            StringBuilder errorsMessage = new StringBuilder();
            foreach (var error in errors)
            {
                errorsMessage.Append(error.Description);
            }
            return new(errorsMessage.ToString(), System.Net.HttpStatusCode.BadRequest);
        }
        return new BaseResponse<string>("User registered successfully", System.Net.HttpStatusCode.Created);
        
    }
}
