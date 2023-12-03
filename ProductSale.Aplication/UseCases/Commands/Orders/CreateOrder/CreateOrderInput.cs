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
        public HashSet<OrderProduct> OrderProducts { get; private set; }

        public CreateOrderInput(Stage stage, double amount, double profit, int customerId, HashSet<OrderProduct> orderProducts)
        {
            Stage = stage;
            Amount = amount;
            Profit = profit;
            CustomerId = customerId;
            OrderProducts = orderProducts;
        }
    }
}