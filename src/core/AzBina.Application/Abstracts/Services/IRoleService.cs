using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzBina.Application.DTOs.RoleDtos;
using AzBina.Application.Shared;

namespace AzBina.Application.Abstracts.Services;

public interface IRoleService
{
    Task<BaseResponse<string?>> CreateRole(RoleCreateDto dto);
}
