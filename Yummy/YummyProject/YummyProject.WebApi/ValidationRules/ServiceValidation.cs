using FluentValidation;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.ValidationRules
{
    public class ServiceValidation:AbstractValidator<Service>
    {
        public ServiceValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlıq boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Məzmun boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(150).WithMessage("Uzunluq 150 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.IconUrl).NotEmpty().WithMessage("Url boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
        }
    }
}
