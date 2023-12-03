using ProductSale.Domain.Repositories;
using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrderProducts
{
    public sealed class UpdateOrderProductsUseCase : IUseCase<UpdateOrderProductsInput, UseCaseResult<UpdateOrderProductsOutput>>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderProductsUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<UseCaseResult<UpdateOrderProductsOutput>> Execute(UpdateOrderProductsInput input = null)
        {
            var orderProducts = input.ToEntity();

            List<OrderProduct> updatedOrderProducts = new();

            foreach (var orderProduct in orderProducts)
            {
                var updatedOrderProduct = _orderRepository.UpdateOrderProduct(orderProduct);
                updatedOrderProducts.Add(updatedOrderProduct);
            }

            var output = new UpdateOrderProductsOutput(updatedOrderProducts);

            return Task.FromResult(new UseCaseResult<UpdateOrderProductsOutput>(output, true, "Order products updated"));
        }
    }
}
