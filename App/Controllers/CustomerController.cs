using Microsoft.AspNetCore.Mvc;
using ProductSale.DTOs.Customers;
using Microsoft.AspNetCore.JsonPatch;
using ProductSale.App.Services.CustomerService;

namespace ProductSale.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public void Create(InputCustomerDto customerDto) => _customerService.CreateCustomer(customerDto);

        [HttpGet("{customerId}")]
        public OutputCustomerDto GetById(int customerId) => _customerService.GetCustomerById(customerId);

        [HttpGet]
        public List<OutputCustomerDto> Get() => _customerService.GetAllCustomers();

        [HttpPatch("{customerId}")]
        public void Update(int customerId, [FromBody] JsonPatchDocument customer) => _customerService.UpdateCustomer(customerId, customer);
    }
}
