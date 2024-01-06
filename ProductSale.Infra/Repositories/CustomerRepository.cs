using Microsoft.EntityFrameworkCore;
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
            return _context.Customers.AsNoTracking().ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            var customerToUpdate = _context.Customers.SingleOrDefault(x => x.Id == id);

            customerToUpdate.Update(customer);

            _context.Save();

            return customerToUpdate;
        }
    }
}
