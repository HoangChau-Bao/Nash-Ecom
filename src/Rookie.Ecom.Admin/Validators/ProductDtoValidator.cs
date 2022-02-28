using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Admin.Validators
{
    public class ProductDtoValidator : BaseValidator<ProductDto>
    {
        public ProductDtoValidator(IProductService productService)
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Name)));

            RuleFor(m => m.Desc)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Desc)));

            RuleFor(m => m.Price)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Price)));

            RuleFor(m => m.Quantity)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Quantity)));
        }
    }
}
