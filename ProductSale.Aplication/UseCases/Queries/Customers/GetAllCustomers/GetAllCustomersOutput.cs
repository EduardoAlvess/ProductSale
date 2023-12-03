using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Queries.Customers.GetAllCustomers
{
    public class GetAllCustomersOutput
    {
        public List<OutputCustomer> Customers { get; set; }

        public GetAllCustomersOutput(List<Customer> customers)
        {
            Customers = customers.Select(c =>
                        new OutputCustomer(
                            c.Id, 
                            c.Name, 
                            c.Phone, 
                            c.Register
                            )
                        ).ToList();
        }
    }

    public record OutputCustomer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Register { get; private set; }

        public OutputCustomer(int id, string name, string phone, string register)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Register = register;
        }
    }
}