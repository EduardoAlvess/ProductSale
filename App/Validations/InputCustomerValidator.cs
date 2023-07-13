using FluentValidation;
using ProductSale.DTOs.Customers;
using System.Text.RegularExpressions;

namespace ProductSale.App.Validations
{
    public class InputCustomerValidator : AbstractValidator<InputCustomerDto>
    {
        public InputCustomerValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                    .WithMessage("Name must not be null")
                .MinimumLength(3)
                    .WithMessage("Name length must be more than 3 characteres")
                .MaximumLength(50)
                    .WithMessage("Name length must be less than 50 characteres");

            RuleFor(m => m.Phone)
                .NotEmpty()
                    .WithMessage("Phone must not be null")
                .Matches("(?:\\d{2}\\s\\d{5}-\\d{4}|\\d{2}\\s\\d{9}|\\d{11})")
                    .WithMessage("Phone not valid");

            RuleFor(m => m.Register)
                .NotEmpty()
                    .WithMessage("Register must not be null")
                .Matches("(?:(?:\\d{3}\\.){2}\\d{3}-\\d{2}|\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}-\\d{2})")
                    .WithMessage("Register not valid");
        }
    }
}
