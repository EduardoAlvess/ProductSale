using ProductSale.Domain.Entities;
using ProductSale.Domain.Enums;

namespace ProductSale.Aplication.UseCases.Queries.Orders.GetOrderById
{
    public record GetOrderByIdOutput
    {
        public int Id { get; private set; }
        public Stage Stage { get; private set; }
        public double Value { get; private set; }
        public double Profit { get; private set; }
        public int CustomerId { get; private set; }
        public IReadOnlyList<OrderProduct> OrderProducts { get; private set; }

        public GetOrderByIdOutput(Order order)
        {
            Id = order.Id;
            Stage = order.Stage;
            Value = order.Value;
            Profit = order.Profit;
            CustomerId = order.CustomerId;
            OrderProducts = order.OrderProducts;
        }
    }
}