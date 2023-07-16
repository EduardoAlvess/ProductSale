using ProductSale.Infra.DB;
using ProductSale.Core.Models;
using ProductSale.Infra.Cache;
using ProductSale.DTOs.Customers;
using ProductSale.Core.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.JsonPatch.Operations;
using ProductSale.Core.Exceptions.CustomerExceptions;

namespace ProductSale.App.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IDbContext _db;
        private readonly ICacheProvider _cache;

        public CustomerService(IDbContext dbContext, ICacheProvider cache)
        {
            _db = dbContext;
            _cache = cache;
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

            _cache.DeleteCache("customers");

            _db.Save();
        }

        public List<OutputCustomerDto> GetAllCustomers()
        {
            List<OutputCustomerDto> customerDtos = new();

            List<Customer> customers;

            var cacheData = _cache.Get<List<Customer>>("customers");

            if (cacheData is not null && cacheData.Count() > 0)
                customers = cacheData;
            else
            {
                customers = _db.Customers.ToList();
                _cache.Set("customers", customers);
            }

            foreach(var customer in customers)
            {
                List<Order> order = _db.Orders.Where(o => o.CustomerId == customer.Id).ToList();

                OutputCustomerDto customerDto = new()
                {
                    Name = customer.Name,
                    Phone = customer.Phone,
                    Register = customer.Register,
                    Orders = order
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

                List<Order> orders = _db.Orders.Where(o => o.CustomerId == id).ToList();

                OutputCustomerDto customerDto = new()
                {
                    Name = customer.Name,
                    Phone = customer.Phone,
                    Orders = orders,
                    Register = customer.Register
                };

                return customerDto;
            }
            catch (InvalidOperationException ex)
            {
                throw new NotFoundException("Can't find a customer with this id");
            }
        }

        public void UpdateCustomer(int id, JsonPatchDocument inputCustomer)
        {
            if (!IsRegisterValid(inputCustomer.Operations))
                throw new RegisterInvalidException("Register invalid");

            Customer customer = _db.Customers.Single(p => p.Id == id);

            inputCustomer.ApplyTo(customer);

            _cache.DeleteCache("customers");

            _db.Save();
        }

        private bool IsRegisterValid(List<Operation> operations)
        {
            foreach (var operation in operations)
            {
                if (operation.path.ToLower() == "/register")
                {
                    var pattern = "(?:(?:\\d{3}\\.){2}\\d{3}-\\d{2}|\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}-\\d{2})";

                    return Regex.Match(operation.value.ToString(), pattern).Success ? true : false;

                }
            }

            return true;
        }
    }
}
