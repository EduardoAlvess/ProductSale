using ProductSale.Domain.Repositories;
using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Commands.Orders.CreateOrder
{
    public sealed class CreateOrderUseCase : IUseCase<CreateOrderInput, UseCaseResult<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<UseCaseResult<int>> Execute(CreateOrderInput input = null)
        {
            if (input is null)
            {
                throw new ArgumentNullException("The sent informations are invalid", nameof(CreateOrderInput));
            }

            input.SetProfit(CalculateProfit(input));

            Order order = input.ToEntity();

            _unitOfWork.OrderRepository.CreateOrder(order);

            foreach (var orderProduct in order.OrderProducts)
            {
                var product = _unitOfWork.ProductRepository.GetProductById(orderProduct.ProductId);

                if (product.AmountInStock < orderProduct.Quantity)
                {
                    throw new ApplicationException(
                        $"The stock of the product with Id {orderProduct.ProductId} is lower than the quantity provided");
                }

                product.RemoveFromStock(orderProduct.Quantity);
            }

            _unitOfWork.SaveChanges();

            var createdOrderId = _unitOfWork.OrderRepository.GetAllCustomerOrders(order.CustomerId).Last().Id;

            return Task.FromResult(new UseCaseResult<int>(createdOrderId, true, "Order created"));
        }

        private double CalculateProfit(CreateOrderInput order)
        {
            double totalProductsProdCost = 0;

            foreach (var orderProduct in order.OrderProducts)
            {
                var productProdCost = _unitOfWork.ProductRepository.GetProductById(orderProduct.ProductId).ProductionCost;

                var totalCost = orderProduct.Quantity * productProdCost;

                totalProductsProdCost += totalCost;
            }

            double profit = order.Amount - totalProductsProdCost;

            return profit;
        }
    }
}
