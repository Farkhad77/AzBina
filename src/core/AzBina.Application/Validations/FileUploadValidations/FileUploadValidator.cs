using AzBina.Application.DTOs.FileUploadDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.Validations.FileUploadValidations;

public class FileUploadValidator : AbstractValidator<FileUploadDto>
{
  
    public FileUploadValidator()
    {
        RuleFor(x => x.File)
            .NotNull().WithMessage("Fayl boş ola bilməz.")
            .NotEmpty().WithMessage("Fayl seçilməlidir.")
            .Must(file => file.Length > 0).WithMessage("Faylın ölçüsü sıfırdan böyük olmalıdır.");
            
    }
}
