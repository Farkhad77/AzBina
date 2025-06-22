using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.UserDtos;
using AzBina.Application.Shared;
using AzBina.Application.Shared.Settings;
using AzBina.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Persistance.Services;

public class UserService : IUserService
{
    private UserManager<AppUser> _userManager { get; }
    private SignInManager<AppUser> _signInManager { get; }
    private JWTSettings _jwtSettings { get; }
    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IOptions<JWTSettings> jwtSetting)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSetting.Value;
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
                errorsMessage.Append(error.Description+";");
            }
            return new(errorsMessage.ToString(), System.Net.HttpStatusCode.BadRequest);
        }
        return new BaseResponse<string>("User registered successfully", System.Net.HttpStatusCode.Created);
        
    }

    public async Task<BaseResponse<TokenResponse>> Login(UserLoginDto dto)
    {
        var existedEmail = await _userManager.FindByEmailAsync(dto.Email);
        if (existedEmail is null)
        {
            return new("Email or password is wrong.", null, System.Net.HttpStatusCode.NotFound);
        }

        SignInResult signInResult = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, true, true);

        if(!signInResult.Succeeded)
        {
            return new("Email or password is wrong.", null, System.Net.HttpStatusCode.NotFound);
        }

        var token = GenerateJwtToken(dto.Email);
        var expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes);
        TokenResponse tokenResponse = new()
        {
            Token = token,
            ExpireDate = expires
        };
        return new("Token generated", tokenResponse, System.Net.HttpStatusCode.OK);
    }

    private string GenerateJwtToken(string userEmail)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, userEmail),
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid(). ToString()),

        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
