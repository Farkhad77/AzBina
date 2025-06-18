using AzBina.Application.DTOs.TownshipDtos;
using FluentValidation;

namespace AzBina.Application.Validations.TownshipValidations;

public class TownshipUpdateDtoValidator : AbstractValidator<TownshipUpdateDto>
{
    public TownshipUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Township name cannot be empty.")
            .NotNull().WithMessage("Township name cannot be null.")
            .MaximumLength(100).WithMessage("Township name cannot exceed 100 characters.");
        RuleFor(x => x.DisctrictId)
            .NotEmpty().WithMessage("District ID cannot be empty.")
            .NotNull().WithMessage("District ID cannot be null.");
    }
}
