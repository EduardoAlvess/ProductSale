using ProductSale.Domain.Entities;
using ProductSale.Domain.Enums;

namespace ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrder
{
    public record UpdateOrderOutput
    {
        public int Id { get; private set; }
        public Stage Stage { get; private set; }
        public double Amount { get; private set; }
        public double Profit { get; private set; }
        public int CustomerId { get; private set; }
        public IReadOnlyList<OrderProduct> OrderProducts { get; private set; }

        public UpdateOrderOutput(Order order)
        {
            Id = order.Id;
            Stage = order.Stage;
            Amount = order.Amount;
            Profit = order.Profit;
            CustomerId = order.CustomerId;
            OrderProducts = order.OrderProducts;
        }
    }
}