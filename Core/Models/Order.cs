using ProductSale.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public ICollection<Product> Products { get; set; }
    }
}
