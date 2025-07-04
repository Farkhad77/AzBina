﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.Abstracts.Services;

public interface IFileUpload
{
    Task<string> UploadAsync(IFormFile file);
}
