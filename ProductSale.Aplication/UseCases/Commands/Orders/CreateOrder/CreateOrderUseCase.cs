using ProductSale.Domain.Repositories;
using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Commands.Orders.CreateOrder
{
    public sealed class CreateOrderUseCase : IUseCase<CreateOrderInput, UseCaseResult<int>>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<UseCaseResult<int>> Execute(CreateOrderInput input = null)
        {
            Order order = input.ToEntity();

            int orderCreatedId = _orderRepository.CreateOrder(order);

            return Task.FromResult(new UseCaseResult<int>(orderCreatedId, true, "Order created"));
        }
    }
}
