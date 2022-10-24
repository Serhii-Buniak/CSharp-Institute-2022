using FluentValidation;

namespace CityMicroService.BLL.DTOs;

public class CategoryValidation : AbstractValidator<CategoryDTO>
{
    public CategoryValidation()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();
    }
}