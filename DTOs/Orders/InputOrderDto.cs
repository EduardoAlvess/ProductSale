using ProductSale.Core.Enums;
using ProductSale.DTOs.Products;

namespace ProductSale.DTOs.Orders
{
    public class InputOrderDto
    {
        public Stage Stage { get; set; }
        public double Amount { get; set; }
        public double Profit { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OutputProductDto> Products { get; set; }
    }
}
