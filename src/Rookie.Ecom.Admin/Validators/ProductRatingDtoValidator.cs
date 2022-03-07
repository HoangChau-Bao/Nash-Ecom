using FluentValidation;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Admin.Validators
{
    public class ProductRatingDtoValidator : BaseValidator<ProductRatingDto>
    {
        public ProductRatingDtoValidator(IProductRatingDto productRatingDto)
        {
            RuleFor(m => m.Comment)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Comment)));

            RuleFor(m => m.Rating)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Rating)));
        }
    }
}
