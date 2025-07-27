using FluentValidation;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.ValidationRules
{
    public class ChefValidation:AbstractValidator<Chef>
    {
        public ChefValidation()
        {
            RuleFor(x=>x.NameSurname).NotEmpty().WithMessage("Ad ve soyad boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(20).WithMessage("Uzunluq 20 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlıq boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(50).WithMessage("Uzunluq 50 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Mezmun boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Şəkil boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
        }
    }
}
