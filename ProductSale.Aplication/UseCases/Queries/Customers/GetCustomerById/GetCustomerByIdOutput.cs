using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Queries.Customers.GetCustomerById
{
    public sealed record GetCustomerByIdOutput
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Register { get; private set; }

        public GetCustomerByIdOutput(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Phone = customer.Phone;
            Register = customer.Register;
        }
    }
}
