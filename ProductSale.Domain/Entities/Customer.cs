using System.ComponentModel.DataAnnotations;

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
    }
}
