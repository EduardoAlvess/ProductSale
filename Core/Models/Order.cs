using ProductSale.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProductSale.Core.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Stage Stage { get; set; }
        public double Amount { get; set; }
        public double Profit { get; set; }
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }

        public Order(double amount, double profit, int customerId, List<Product> products)
        {
            Amount = amount;
            Profit = profit;
            Products = products;
            CustomerId = customerId;
        }
    }
}
