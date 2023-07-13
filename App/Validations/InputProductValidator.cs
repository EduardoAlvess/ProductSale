using FluentValidation;
using ProductSale.DTOs.Products;

namespace ProductSale.App.Validations
{
    public class InputProductValidator : AbstractValidator<InputProductDto>
    {
        public InputProductValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                    .WithMessage("Name must not be null")
                .MinimumLength(3)
                    .WithMessage("Name length must be more than 3 characteres")
                .MaximumLength(50)
                    .WithMessage("Name length must be less than 50 characteres");

            RuleFor(m => m.Description)
                .NotEmpty()
                    .WithMessage("Description must not be null")
                .MinimumLength(3)
                    .WithMessage("Description length must be more than 3 characteres")
                .MaximumLength(3000)
                    .WithMessage("Description length must be less than 3000 characteres");

            RuleFor(m => m.Value)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Value must not be less than 0");

            RuleFor(m => m.AmountInStock)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("AmountInStock must not be less than 0");

            RuleFor(m => m.ProductionCost)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("ProductionCost must not be less than 0");
        }
    }
}
