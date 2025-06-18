using AzBina.Application.Abstracts.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Persistance.Services;

public class FileUploadService : IFileUpload
{
    private readonly IWebHostEnvironment _env;
    public FileUploadService(IWebHostEnvironment env)
    {
        _env = env ;
    }
    public async Task<string> UploadAsync(IFormFile file)
    {
        var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var originalFileName = Path.GetFileNameWithoutExtension(file.FileName);
        var extension = Path.GetExtension(file.FileName);
        var fileName = originalFileName + extension;
        var filePath = Path.Combine(uploadsFolder, fileName);

        int count = 1;
        while (System.IO.File.Exists(filePath))
        {
            var tempFileName = $"{originalFileName}({count}){extension}";
            filePath = Path.Combine(uploadsFolder, tempFileName);
            fileName = tempFileName;
            count++;
        }

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"/uploads/{fileName}";
    }
}



