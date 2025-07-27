using FluentValidation;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.ValidationRules
{
    public class CategoryValidation:AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategoriya adı boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(20).WithMessage("Uzunluq 20 simvoldan çox olmamalıdır!");
            RuleFor(X => X.Products).NotNull();
        }
    }
}
