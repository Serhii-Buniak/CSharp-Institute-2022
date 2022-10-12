using FluentValidation;

namespace BLL.DTOs;

internal class CategoryValidation : AbstractValidator<CategoryDTO>
{
    public CategoryValidation()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();
    }
}