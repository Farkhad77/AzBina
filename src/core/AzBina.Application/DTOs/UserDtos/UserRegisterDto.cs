﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.DTOs.UserDtos;

public record class UserRegisterDto
{
    public string Fullname { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;

}
