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
        public double Value { get; private set; }
        public double Profit { get; private set; }
        public int CustomerId { get; private set; }

        public IReadOnlyList<OrderProduct> OrderProducts => _orderProducts;
        private readonly List<OrderProduct> _orderProducts = new();

        public Order(Stage stage, double value, double profit)
        {
            Stage = stage;
            Value = value;
            Profit = profit;
        }

        public Order(Stage stage, double value, double profit, int customerId, HashSet<OrderProduct> orderProducts)
        {
            Stage = stage;
            Value = value;
            Profit = profit;
            CustomerId = customerId;

            _orderProducts.AddRange(orderProducts);
        }

        public void Update(double value, double profit, Stage stage)
        {
            Ensure.GreaterThanZero(value, "The order value must be greather than 0", nameof(value));
            Ensure.GreaterThanOrEqualToZero(profit, "The order profit must be greather than or equal to 0", nameof(profit));

            Value = value;
            Profit = profit;
            Stage = stage;
        }

        public void SetProfit(double profit)
        {
            Profit = profit;
        }
    }
}
