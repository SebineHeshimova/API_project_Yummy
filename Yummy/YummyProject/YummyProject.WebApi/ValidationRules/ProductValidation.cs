using FluentValidation;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.ValidationRules
{
    public class ProductValidation:AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product adi bosh ola bilmez!");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Product adinda en az 2 herf olmalidir!"); 
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Product adinda en chox 50 herf olmalidir!");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product adi bosh ola bilmez!");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product adi bosh ola bilmez!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Mehsul qiymeti bos buraxila bilmez!").GreaterThan(0).WithMessage("Mehsul qiymeti menfi ola bilmez!");
            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Mehsul achiqlamasi bosh ola bilmez!").MaximumLength(200).WithMessage("200 simvoldan chox olmamalidir!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Mehsul uchun shekil elave edilmelidir!").MaximumLength(200).WithMessage("Uzunluq 200 simvoldan chox ola bilmez!");
        }
    }
}
