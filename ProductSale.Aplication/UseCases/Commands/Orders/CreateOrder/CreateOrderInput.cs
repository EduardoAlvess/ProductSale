using ProductSale.Domain.Entities;
using ProductSale.Domain.Enums;

namespace ProductSale.Aplication.UseCases.Commands.Orders.CreateOrder
{
    public record CreateOrderInput
    {
        public Stage Stage { get; private set; }
        public double Amount { get; private set; }
        public double Profit { get; private set; }
        public int CustomerId { get; private set; }
        public HashSet<OrderProductInput> OrderProducts { get; private set; }

        public CreateOrderInput(Stage stage, double amount, double profit, int customerId, HashSet<OrderProductInput> orderProducts)
        {
            Stage = stage;
            Amount = amount;
            Profit = profit;
            CustomerId = customerId;
            OrderProducts = orderProducts;
        }

        public Order ToEntity()
        {
            var orderProducts = OrderProducts.Select(op =>
                                    new OrderProduct(op.OrderId, op.ProductId, op.Quantity)
                                    ).ToHashSet();

            return new Order(Stage, Amount, Profit, orderProducts);
        }
    }

    public record OrderProductInput
    {
        public int OrderId { get; private set; }
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }

        public OrderProductInput(int orderId, int productId, int quantity)
        {
            OrderId = orderId;
            Quantity = quantity;
            ProductId = productId;
        }
    }
}