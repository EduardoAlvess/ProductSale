using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Commands.Customers.UpdateCustomer
{
    public record UpdateCustomerOutput
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Register { get; private set; }

        public UpdateCustomerOutput(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Phone = customer.Phone;
            Register = customer.Register;
        }
    }
}