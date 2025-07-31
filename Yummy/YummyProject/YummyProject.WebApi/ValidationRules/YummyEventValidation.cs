using FluentValidation;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.ValidationRules
{
    public class YummyEventValidation:AbstractValidator<YummyEvent>
    {
        public YummyEventValidation()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlıq boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(100).WithMessage("Uzunluq 100 simvoldan çox olmamalıdır!");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Mezmun boş olmamalıdır!").
                MinimumLength(3).WithMessage("Uzunluq 3 simvoldan qısa olmamalıdır!").
                MaximumLength(150).WithMessage("Uzunluq 150 simvoldan çox olmamalıdır!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Mehsul qiymeti bos buraxila bilmez!")
                .GreaterThan(0).WithMessage("Mehsul qiymeti menfi ola bilmez!");
            RuleFor(x => x.imageUrl).NotEmpty().WithMessage("Mehsul uchun shekil elave edilmelidir!")
                .MinimumLength(3).WithMessage("Uzunluq 3 simvoldan az ola bilmez")
                .MaximumLength(200).WithMessage("Uzunluq 200 simvoldan chox ola bilmez!");

        }
    }
}
