using ProductSale.Infra.DB;
using ProductSale.Core.Models;
using ProductSale.Core.Exceptions.ProductExceptions;
using Microsoft.AspNetCore.JsonPatch;
using ProductSale.App.Services.CustomerService;
using ProductSale.DTOs.Customers;

namespace ProductSale.App.Services.ProductService
{
    public class CustomerService : ICustomerService
    {
        private readonly IDbContext _db;

        public CustomerService(IDbContext dbContext)
        {
            _db = dbContext;
        }

        public void CreateCustomer(InputCustomerDto inputCustomerDto)
        {
            Customer customer = new Customer()
            {
                Name = inputCustomerDto.Name,
                Phone = inputCustomerDto.Phone,
                Register = inputCustomerDto.Register
            };

            _db.Customers.Add(customer);

            _db.Save();
        }

        public List<OutputCustomerDto> GetAllCustomers()
        {
            List<OutputCustomerDto> customerDtos = new();

            List<Customer> customers = _db.Customers.ToList();

            foreach(var customer in customers)
            {
                OutputCustomerDto customerDto = new()
                {
                    Name = customer.Name,
                    Phone = customer.Phone,
                    Register = customer.Register,
                    Orders = customer.Orders
                };

                customerDtos.Add(customerDto);
            }

            return customerDtos;
        }

        public OutputCustomerDto GetCustomerById(int id)
        {
            try
            {
                Customer customer = _db.Customers.Single(p => p.Id == id);

                OutputCustomerDto customerDto = new()
                {
                    Name = customer.Name,
                    Phone = customer.Phone,
                    Orders = customer.Orders,
                    Register = customer.Register
                };

                return customerDto;
            }
            catch (InvalidOperationException ex)
            {
                throw new ProductNotFoundException("Can't find a product with this id");
            }
        }

        public void UpdateCustomer(int id, JsonPatchDocument inputCustomer)
        {
            foreach(var operation in inputCustomer.Operations)
            {
                if(String.IsNullOrEmpty(operation.op))
                    throw new ProductUpdateOperationRequiredException("Operation is required");
                if(String.IsNullOrEmpty(operation.path))
                    throw new ProductUpdatePathRequiredException("Path is required");
                if (String.IsNullOrEmpty(operation.value.ToString()))
                    throw new ProductUpdateValueRequiredException("Value is required");
            }

            Customer customer = _db.Customers.Single(p => p.Id == id);

            inputCustomer.ApplyTo(customer);

            _db.Save();
        }
    }
}
