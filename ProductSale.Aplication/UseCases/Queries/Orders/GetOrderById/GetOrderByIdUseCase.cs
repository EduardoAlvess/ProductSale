using ProductSale.Domain.Repositories;

namespace ProductSale.Aplication.UseCases.Queries.Orders.GetOrderById
{
    public sealed class GetOrderByIdUseCase : IUseCase<int, UseCaseResult<GetOrderByIdOutput>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<UseCaseResult<GetOrderByIdOutput>> Execute(int input = 0)
        {
            var order = _orderRepository.GetOrderById(input);

            var output = new GetOrderByIdOutput(order);

            return Task.FromResult(new UseCaseResult<GetOrderByIdOutput>(output, true));
        }
    }
}
