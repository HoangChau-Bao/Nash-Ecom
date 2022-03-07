using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Admin.Validators
{
    public class ProductPictureDtoValidator : BaseValidator<ProductPictureDto>
    {
        public ProductPictureDtoValidator(IProductPictureService productPictureService)
        {
            RuleFor(m => m.PictureUrl)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.PictureUrl)));

            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Title)));


        }
    }
}
