using FluentValidation;
using ProductSale.Infra.DB;
using ProductSale.DTOs.Orders;
using ProductSale.Core.Exceptions;

namespace ProductSale.App.Validations
{
    public class InputOrderValidator : AbstractValidator<InputOrderDto>
    {
        private readonly IDbContext _db;

        public InputOrderValidator(IDbContext db)
        {
            _db = db;

            RuleFor(m => m.Stage)
                .NotNull()
                    .WithMessage("Stage must not be null")
                .IsInEnum()
                    .WithMessage("Stage must be valid");

            RuleFor(m => m.Amount)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Amount must not be less than 0");

            RuleFor(m => m.CustomerId)
                .Must(DoesCustomerExist)
                    .WithMessage("Customer don't exist");

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
            try
            {
                var productsIds = _db.Products.Select(c => c.Id).ToList();

                return productsIds.Contains(productId) ? true : false;
            }
            catch(NullReferenceException ex)
            {
                throw new NotFoundException("Can't find a product with this id");
            }
        }

        private bool DoesCustomerExist(int customerId)
        {
            try
            {
                var customersIds = _db.Customers.Select(c => c.Id).ToList();

                return customersIds.Contains(customerId) ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private int GetAmountInStock(int productId)
        {
            try
            {
                return _db.Products.First(p => p.Id == productId).AmountInStock;
            }
            catch(Exception ex)
            {
                throw new NotFoundException("Can't find a product with this id");
            }
        }
    }
}
