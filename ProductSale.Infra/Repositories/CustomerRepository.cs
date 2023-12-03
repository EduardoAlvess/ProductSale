using ProductSale.Domain.Entities;

namespace ProductSale.Domain.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public int CreateCustomer(Customer customer)
        {
            return 1;
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
