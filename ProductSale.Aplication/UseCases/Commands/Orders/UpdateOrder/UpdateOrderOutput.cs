using ProductSale.Domain.Entities;
using ProductSale.Domain.Enums;

namespace ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrder
{
    public record UpdateOrderOutput
    {
        public int Id { get; private set; }
        public Stage Stage { get; private set; }
        public double Value { get; private set; }
        public double Profit { get; private set; }
        public int CustomerId { get; private set; }
        public IReadOnlyList<OrderProductOutput> OrderProducts { get; private set; }

        public UpdateOrderOutput(Order order)
        {
            Id = order.Id;
            Stage = order.Stage;
            Value = order.Value;
            Profit = order.Profit;
            CustomerId = order.CustomerId;
            OrderProducts = order.OrderProducts.Select(op => 
                                                    new OrderProductOutput(op.Id, op.OrderId, op.ProductId, op.Quantity)
                                                    ).ToList();
        }
    }

    public record OrderProductOutput
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }

        public OrderProductOutput(int id, int orderId, int productId, int quantity)
        {
            Id = id;
            OrderId = orderId;
            Quantity = quantity;
            ProductId = productId;
        }
    }
}