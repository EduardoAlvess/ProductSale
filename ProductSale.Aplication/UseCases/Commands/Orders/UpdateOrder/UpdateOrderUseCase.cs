using ProductSale.Domain.Entities;
using ProductSale.Domain.Repositories;

namespace ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrder
{
    public sealed class UpdateOrderUseCase : IUseCase<UpdateOrderInput, UseCaseResult<UpdateOrderOutput>>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<UseCaseResult<UpdateOrderOutput>> Execute(UpdateOrderInput input = null)
        {
            Order order = new(input.Stage, input.Amount, input.Profit);

            Order updatedOrder = _orderRepository.UpdateOrder(input.Id, order);

            var output = new UpdateOrderOutput(updatedOrder);

            return Task.FromResult(new UseCaseResult<UpdateOrderOutput>(output, true, "Order updated"));
        }
    }
}
