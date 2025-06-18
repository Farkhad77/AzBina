using AzBina.Application.DTOs.FavoriteDtos;
using FluentValidation;

namespace AzBina.Application.Validations.FavoriteValidations;

public class FavoriteCreateDtoValidator : AbstractValidator<FavoriteCreateDto>
{
    public FavoriteCreateDtoValidator()
    {
        RuleFor(x => x.AdId)
            .NotEmpty().WithMessage("Ad Id cannot be empty.")
            .NotNull().WithMessage("Ad Id cannot be null.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .NotNull().WithMessage("Name cannot be null.");
    }
}
