using ProductSale.Core.Enums;
using ProductSale.Core.Models;

namespace ProductSale.DTOs.Orders
{
    public class InputOrderDto
    {
        public Stage Stage { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
