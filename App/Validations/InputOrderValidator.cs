using FluentValidation;
using ProductSale.DTOs.Orders;

namespace ProductSale.App.Validations
{
    public class InputOrderValidator : AbstractValidator<InputOrderDto>
    {
        public InputOrderValidator()
        {
            RuleFor(m => m.Stage)
                .NotNull()
                    .WithMessage("Stage must not be null")
                .IsInEnum()
                    .WithMessage("Stage must be valid");
        }
    }
}
