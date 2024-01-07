using ProductSale.Domain.Repositories;
using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Commands.Orders.CreateOrder
{
    public sealed class CreateOrderUseCase : IUseCase<CreateOrderInput, UseCaseResult<int>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderUseCase(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public Task<UseCaseResult<int>> Execute(CreateOrderInput input = null)
        {
            if (input is null)
            {
                throw new ArgumentNullException("The sent informations are invalid", nameof(CreateOrderInput));
            }

            input.SetProfit(CalculateProfit(input));

            Order order = input.ToEntity();

            int orderCreatedId = _orderRepository.CreateOrder(order);

            return Task.FromResult(new UseCaseResult<int>(orderCreatedId, true, "Order created"));
        }

        private double CalculateProfit(CreateOrderInput order)
        {
            double totalProductsProdCost = 0;

            foreach (var orderProduct in order.OrderProducts)
            {
                var productProdCost = _productRepository.GetProductById(orderProduct.ProductId).ProductionCost;

                var totalCost = orderProduct.Quantity * productProdCost;

                totalProductsProdCost += totalCost;
            }

            double profit = order.Amount - totalProductsProdCost;

            return profit;
        }
    }
}
