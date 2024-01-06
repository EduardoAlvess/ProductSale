using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Commands.Customers.UpdateCustomer
{
    public record UpdateCustomerInput
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Register { get; private set; }

        public UpdateCustomerInput(string name, string phone, string register)
        {
            Name = name;
            Phone = phone;
            Register = register;
        }

        public Customer ToEntity()
        {
            return new Customer(Name, Phone, Register);
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}