using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.DTOs.FileUploadDtos;

public class FileUploadDto
{
   public  IFormFile File { get; set; } = null!;
}
