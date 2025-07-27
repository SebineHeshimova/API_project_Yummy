using FluentValidation;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.ValidationRules
{
    public class MessageValidation:AbstractValidator<Message>
    {
        public MessageValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(50).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.NameSurname).NotEmpty().WithMessage("Ad ve soyad boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(20).WithMessage("Uzunluq 20 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Mövzu boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.MessageDetails).NotEmpty().WithMessage("Mezmun boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 200 simvoldan çox olmamalıdır!");

        }
    }
}
