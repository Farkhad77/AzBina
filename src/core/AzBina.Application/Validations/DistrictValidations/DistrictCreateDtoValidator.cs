using AzBina.Application.DTOs.DistrictDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.Validations.DistrictValidations;

public class DistrictCreateDtoValidator : AbstractValidator<DistrictCreateDto>
{
    public DistrictCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("District name is required.")
            .MaximumLength(100).WithMessage("District name cannot exceed 100 characters.");
    }
}

