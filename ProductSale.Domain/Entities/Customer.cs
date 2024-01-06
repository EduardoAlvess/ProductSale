using System.ComponentModel.DataAnnotations;
using ProductSale.Domain.Utils;

namespace ProductSale.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Register { get; private set; }

        public Customer(string name, string phone, string register)
        {
            Name = name;
            Phone = phone;
            Register = register;
        }

        public void Update(Customer customer)
        {
            Ensure.NotNull(customer.Name, "The customer name is required", nameof(customer.Name));
            Ensure.NotNull(customer.Phone, "The customer phone is required", nameof(customer.Phone));
            Ensure.NotNull(customer.Register, "The customer register is required", nameof(customer.Register));

            Name = customer.Name;
            Phone = customer.Phone;
            Register = customer.Register;
        }
    }
}
