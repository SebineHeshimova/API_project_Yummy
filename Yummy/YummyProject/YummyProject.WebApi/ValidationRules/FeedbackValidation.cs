using FluentValidation;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.ValidationRules
{
    public class FeedbackValidation:AbstractValidator<Feedback>
    {
        public FeedbackValidation()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlıq boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.NameSurname).NotEmpty().WithMessage("Ad ve soyad boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(20).WithMessage("Uzunluq 20 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.Comment).NotEmpty().WithMessage("Koment boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(150).WithMessage("Uzunluq 150 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Şəkil boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
        }
    }
}
