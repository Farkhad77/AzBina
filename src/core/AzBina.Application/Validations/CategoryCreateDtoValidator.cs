using AzBina.Application.DTOs.CategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.Validations;

public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
{
    
   public CategoryCreateDtoValidator()
 {
    RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Kateqoriya adı boş ola bilməz.")
           .MaximumLength(50).WithMessage("Kateqoriya adı maksimum 50 simvol ola bilər.");
 }

    
}
