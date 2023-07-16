using ProductSale.Core.Models;

namespace ProductSale.DTOs.Customers
{
    public class OutputCustomerDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Register { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
