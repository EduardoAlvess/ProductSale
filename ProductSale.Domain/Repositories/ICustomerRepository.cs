using ProductSale.Domain.Entities;

namespace ProductSale.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer UpdateCustomer(int id, Customer customer);
        int CreateCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
    }
}
