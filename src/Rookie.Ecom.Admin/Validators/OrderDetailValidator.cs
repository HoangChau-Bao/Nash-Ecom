using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;

namespace Rookie.Ecom.Admin.Validators
{
    public class OrderDetailValidator : BaseValidator<OrderDetailDto>
    {
        public OrderDetailValidator(IOrderDetailService orderDetailService)
        {
            RuleFor(m => m.UnitPrice)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.UnitPrice)));

            RuleFor(m => m.ProductQuantity)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.ProductQuantity)));

            RuleFor(m => m.Total)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Total)));

            RuleFor(m => m.ShippingAddress)
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.ShippingAddress)));

            
        }
    }
}
