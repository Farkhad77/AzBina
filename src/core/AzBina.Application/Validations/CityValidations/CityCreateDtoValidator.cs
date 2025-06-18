using AzBina.Application.DTOs.CityDtos;
using FluentValidation;

namespace AzBina.Application.Validations.CityValidations;

public class CityCreateDtoValidator : AbstractValidator<CityCreateDto>
{
    public CityCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("City name cannot be empty.")
            .NotNull().WithMessage("City name cannot be null.")
            .MaximumLength(100).WithMessage("City name cannot exceed 100 characters.");
    }
}


