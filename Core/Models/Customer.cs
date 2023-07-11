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
        public List<Order>? Orders { get; set; }

        public Customer(string name, string phone, string register, List<Order> orders = null)
        {
            Name = name;
            Phone = phone;
            Register = register;
            Orders = orders;
        }
    }
}
