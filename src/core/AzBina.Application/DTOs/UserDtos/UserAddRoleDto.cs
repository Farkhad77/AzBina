using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.DTOs.UserDtos;

public record class UserAddRoleDto
{
    public Guid UserId { get; set; }
    public List<Guid> RolesId { get; set; }
    
}
