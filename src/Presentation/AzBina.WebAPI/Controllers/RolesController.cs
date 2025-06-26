using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.RoleDtos;
using AzBina.Application.Shared.Helpers;
using AzBina.Persistance.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzBina.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private IRoleService _roleService { get; }

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    // GET: api/<RolesController>
    [HttpGet("permissions")]

    public IActionResult GetAllPermissions()
    {
        var permissions = PermissionHelper.GetAllPermissions();
        return Ok(permissions);

    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(RoleCreateDto dto)
    {
        var result = await _roleService.CreateRole(dto);
        return StatusCode((int)result.StatusCode, result);
    }
}
