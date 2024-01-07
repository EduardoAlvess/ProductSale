using System.ComponentModel.DataAnnotations;
using ProductSale.Domain.Enums;
using ProductSale.Domain.Utils;

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

        public IReadOnlyList<OrderProduct> OrderProducts => _orderProducts;
        private readonly List<OrderProduct> _orderProducts = new();

        public Order(Stage stage, double amount, double profit)
        {
            Stage = stage;
            Amount = amount;
            Profit = profit;
        }

        public Order(Stage stage, double amount, double profit, int customerId, HashSet<OrderProduct> orderProducts)
        {
            Stage = stage;
            Amount = amount;
            Profit = profit;
            CustomerId = customerId;

            _orderProducts.AddRange(orderProducts);
        }

        public void Update(Order order)
        {
            Ensure.GreaterThanZero(order.Amount, "The order amount must be greather than 0", nameof(order.Amount));
            
            Amount = order.Amount;
            Stage = order.Stage;
        }
    }
}
