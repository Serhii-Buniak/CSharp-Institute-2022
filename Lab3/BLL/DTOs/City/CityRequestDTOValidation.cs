﻿using FluentValidation;

namespace BLL.DTOs;

internal class CityRequestDTOValidation : AbstractValidator<CityRequestDTO>
{
    public CityRequestDTOValidation()
    {
        RuleFor(x => x.Name)
            .MaximumLength(100)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.CountryId)
            .NotEmpty();
    }
}