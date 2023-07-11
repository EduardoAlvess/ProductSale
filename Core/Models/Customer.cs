using System.ComponentModel.DataAnnotations;

namespace ProductSale.Core.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Register { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
