using AzBina.Application.DTOs.CityDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.Validations.CityValidations;

public class CityUpdateDtoValidator: AbstractValidator<CityUpdateDto>
{
    public CityUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("City name cannot be empty.")
            .NotNull().WithMessage("City name cannot be null.")
            .MaximumLength(100).WithMessage("City name cannot exceed 100 characters.");
    }
}

