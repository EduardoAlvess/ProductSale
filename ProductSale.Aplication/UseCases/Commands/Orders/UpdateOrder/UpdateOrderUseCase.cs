using ProductSale.Domain.Repositories;
using ProductSale.Domain.Entities;
using ProductSale.Application.Services;

namespace ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrder
{
    public sealed class UpdateOrderUseCase : IUseCase<UpdateOrderInput, UseCaseResult<UpdateOrderOutput>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;

        public UpdateOrderUseCase(IUnitOfWork unitOfWork, IOrderService orderService)
        {
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }

        public Task<UseCaseResult<UpdateOrderOutput>> Execute(UpdateOrderInput input = null)
        {
            if (input is null)
            {
                throw new ArgumentNullException("The sent informations are invalid", nameof(UpdateOrderInput));
            }

            var order = _unitOfWork.OrderRepository.GetOrderById(input.Id);

            if (order.Value != input.Value)
            {
                var profit = _orderService.RecalculateProfit(input.Value, order);
                order.Update(input.Value, profit, input.Stage);
            }
            else
            {
                order.Update(order.Value, order.Profit, input.Stage);
            }

            Order updatedOrder = _unitOfWork.OrderRepository.UpdateOrder(order);

            _unitOfWork.SaveChanges();

            var output = new UpdateOrderOutput(updatedOrder);

            return Task.FromResult(new UseCaseResult<UpdateOrderOutput>(output, true, "Order updated"));
        }
    }
}
