using ProductSale.Domain.Entities;
using ProductSale.Infra;

namespace ProductSale.Domain.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContext _context;

        public CustomerRepository(IDbContext context)
        {
            _context = context;
        }

        public int CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.Save();
            return customer.Id;
        }

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
