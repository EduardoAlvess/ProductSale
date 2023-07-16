using ProductSale.Core.Enums;
using ProductSale.DTOs.OrderProducts;

namespace ProductSale.DTOs.Orders
{
    public class OutputOrderDto
    {
        public Stage Stage { get; set; }
        public double Amount { get; set; }
        public double Profit { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OutputOrderProductsDto> OrderProducts { get; set; }
    }
}
