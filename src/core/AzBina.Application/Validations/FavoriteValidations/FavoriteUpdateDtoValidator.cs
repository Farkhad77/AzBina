using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzBina.Application.DTOs.FavoriteDtos;
using FluentValidation;

namespace AzBina.Application.Validations.FavoriteValidations;

public class FavoriteUpdateDtoValidator : AbstractValidator<FavoriteUpdateDto>
{
    public FavoriteUpdateDtoValidator()
    {
        RuleFor(x => x.AdId)
            .NotEmpty().WithMessage("Favorite ID cannot be empty.")
            .NotNull().WithMessage("Favorite ID cannot be null.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("User ID cannot be empty.")
            .NotNull().WithMessage("User ID cannot be null.");
    }
}
