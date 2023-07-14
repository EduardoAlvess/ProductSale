using FluentValidation;
using ProductSale.Infra.DB;
using ProductSale.DTOs.Orders;

namespace ProductSale.App.Validations
{
    public class InputOrderValidator : AbstractValidator<InputOrderDto>
    {
        private readonly IDbContext _db;

        public InputOrderValidator(IDbContext db)
        {
            RuleFor(m => m.Stage)
                .NotNull()
                    .WithMessage("Stage must not be null")
                .IsInEnum()
                    .WithMessage("Stage must be valid");

            RuleFor(m => m.Amount)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Amount must not be less than 0");

            RuleFor(m => m.CustomerId)
                .Must(DoesUserExist)
                    .WithMessage("User don't exist");

            RuleForEach(m => m.OrderProducts).ChildRules(c =>
            {
                c.RuleFor(x => x.Quantity)
                    .GreaterThanOrEqualTo(1)
                        .WithMessage("The quantity must be equal or greater than 1")
                    .LessThanOrEqualTo(x => GetAmountInStock(x.ProductId))
                        .WithMessage("The quantity is higher than the amount in stock");

                c.RuleFor(x => x.ProductId)
                    .Must(DoesProductExist)
                        .WithMessage("The product don't exist");
            });

        }

        private bool DoesProductExist(int productId)
        {
            var productsIds = _db.Products.Select(c => c.Id).ToList();

            return productsIds.Contains(productId) ? true : false;
        }

        private bool DoesUserExist(int customerId)
        {
            var customersIds = _db.Customers.Select(c => c.Id).ToList();

            return customersIds.Contains(customerId) ? true : false;
        }

        private int GetAmountInStock(int productId) => _db.Products.First(p => p.Id == productId).AmountInStock;
    }
}
