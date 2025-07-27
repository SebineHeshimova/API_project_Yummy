using FluentValidation;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.ValidationRules
{
    public class FeatureValidation:AbstractValidator<Feature>
    {
        public FeatureValidation()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlıq boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(50).WithMessage("Uzunluq 50 simvoldan çox olmamalıdır!");
            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt başlıq boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Məzmun boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(150).WithMessage("Uzunluq 150 simvoldan çox olmamalıdır!");
            RuleFor(x => x.VideoUrl).NotEmpty().WithMessage("Video boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Şəkil boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
        }
    }
}
