using FluentValidation;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.ValidationRules
{
    public class ImageValidation:AbstractValidator<Image>
    {
        public ImageValidation()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlıq boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Şəkil boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
        }
    }
}
