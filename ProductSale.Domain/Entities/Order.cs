using System.ComponentModel.DataAnnotations;
using ProductSale.Domain.Enums;

namespace ProductSale.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; private set; }
        public Stage Stage { get; private set; }
        public double Amount { get; private set; }
        public double Profit { get; private set; }
        public int CustomerId { get; private set; }
        public IReadOnlyList<OrderProduct> OrderProducts => _orderProducts.ToList();

        private readonly HashSet<OrderProduct> _orderProducts = new();

        public Order(Stage stage, double amount, double profit)
        {
            Stage = stage;
            Amount = amount;
            Profit = profit;
        }

        public Order(Stage stage, double amount, double profit, HashSet<OrderProduct> orderProducts)
        {
            Stage = stage;
            Amount = amount;
            Profit = profit;

            _orderProducts.UnionWith(orderProducts);
        }
    }
}
