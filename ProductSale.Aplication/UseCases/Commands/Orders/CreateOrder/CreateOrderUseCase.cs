using ProductSale.Application.Services;
using ProductSale.Domain.Entities;
using ProductSale.Domain.Repositories;

namespace ProductSale.Aplication.UseCases.Commands.Orders.CreateOrder
{
    public sealed class CreateOrderUseCase : IUseCase<CreateOrderInput, UseCaseResult<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;

        public CreateOrderUseCase(IUnitOfWork unitOfWork, IOrderService orderService)
        {
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }

        public Task<UseCaseResult<int>> Execute(CreateOrderInput input = null)
        {
            if (input is null)
            {
                throw new ArgumentNullException("The sent informations are invalid", nameof(CreateOrderInput));
            }

            Order order = input.ToEntity();

            order.SetProfit(_orderService.CalculateProfit(input));

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
    }
}
