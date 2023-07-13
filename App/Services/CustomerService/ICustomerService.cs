using Microsoft.AspNetCore.JsonPatch;
using ProductSale.DTOs.Customers;

namespace ProductSale.App.Services.CustomerService
{
    public interface ICustomerService
    {
        void CreateCustomer(InputCustomerDto inputCustomerDto);
        void UpdateCustomer(int id, JsonPatchDocument customer);
        List<OutputCustomerDto> GetAllCustomers();
        OutputCustomerDto GetCustomerById(int id);
    }
}
