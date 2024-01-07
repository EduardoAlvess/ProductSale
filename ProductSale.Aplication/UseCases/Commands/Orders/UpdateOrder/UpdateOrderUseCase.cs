using ProductSale.Domain.Repositories;
using ProductSale.Domain.Entities;

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
            if (input is null)
            {
                throw new ArgumentNullException("The sent informations are invalid", nameof(UpdateOrderInput));
            }

            Order order = input.ToEntity();

            Order updatedOrder = _orderRepository.UpdateOrder(input.Id, order);

            var output = new UpdateOrderOutput(updatedOrder);

            return Task.FromResult(new UseCaseResult<UpdateOrderOutput>(output, true, "Order updated"));
        }
    }
}
