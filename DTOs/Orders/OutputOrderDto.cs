using ProductSale.Core.Enums;
using ProductSale.DTOs.Products;

namespace ProductSale.DTOs.Orders
{
    public class OutputOrderDto
    {
        public Stage Stage { get; set; }
        public double Amount { get; set; }
        public double Profit { get; set; }
        public string CustomerName { get; set; }
        public ICollection<OutputProductDto> Products { get; set; }
    }
}
