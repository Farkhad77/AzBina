using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.UserDtos;
using AzBina.Application.Shared;
using AzBina.Application.Shared.Settings;
using AzBina.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AzBina.Persistance.Services;

public class UserService : IUserService
{
    private UserManager<AppUser> _userManager { get; }
    private SignInManager<AppUser> _signInManager { get; }
    private JWTSettings _jwtSettings { get; }
    private RoleManager<IdentityRole> _roleManager { get; }
    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IOptions<JWTSettings> jwtSetting, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSetting.Value;
        _roleManager = roleManager;
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

        var token = await GenerateTokensAsync(existedEmail);
        return new("Token generated", token, System.Net.HttpStatusCode.OK);
    }

    private async Task<TokenResponse> GenerateTokensAsync(AppUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));

            // Hər rol üçün permission-ları əlavə et
            var identityRole = await _roleManager.FindByNameAsync(role);
            if (identityRole != null)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(identityRole);
                foreach (var claim in roleClaims.Where(c => c.Type == "Permission"))
                {
                    claims.Add(claim);
                }
            }
        }

        var tokenDescriptor = new SecurityTokenDescriptor
            {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = tokenHandler.WriteToken(token);

        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiryDate = DateTime.UtcNow.AddHours(2); // Refresh token valid for 7 days
        user.RefreshToken = refreshToken;
        user.ExpiryDate = refreshTokenExpiryDate;
        await _userManager.UpdateAsync(user);

        return new TokenResponse
        {
            Token = jwt,
            RefreshToken = refreshToken,
            ExpireDate = tokenDescriptor.Expires!.Value
        };
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public async Task<BaseResponse<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var principal = GetPrincipalFromExpiredToken(request.AccessToken);
        if (principal == null)
            return new("Invalid access token", null, HttpStatusCode.Unauthorized);

        var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _userManager.FindByIdAsync(userId!);

        if (user == null )
            return new("User not found", null, HttpStatusCode.NotFound);

        if (user.RefreshToken is null || user.RefreshToken != request.RefreshToken || user.ExpiryDate < DateTime.UtcNow)
            return new("Invalid refresh token", null, HttpStatusCode.BadRequest);

        var newAccessToken = await GenerateTokensAsync(user);
        return new("Token refreshed", newAccessToken, HttpStatusCode.OK);
    }


    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false, // Token-in vaxtını yoxlama
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                return null;

            return principal;
        }
        catch
        {
            return null;
        }
    }

}
