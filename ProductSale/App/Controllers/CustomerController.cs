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

        /// <summary>
        /// Create new customer
        /// </summary>
        /// <remarks>
        /// {"name":"Nick","phone":"51 986026879","register":"853.908.910-75"}
        /// </remarks>
        /// <param name="customerDto">Customer infos</param>
        [HttpPost]
        public void Create(InputCustomerDto customerDto) => _customerService.CreateCustomer(customerDto);

        /// <summary>
        /// Get customer by id
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Customer infos</returns>
        [HttpGet("{customerIdTeste}")]
        public OutputCustomerDto GetById(int customerId) => _customerService.GetCustomerById(customerId);

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List of all customers infos</returns>
        [HttpGet]
        public List<OutputCustomerDto> Get() => _customerService.GetAllCustomers();

        /// <summary>
        /// Update customer infos
        /// </summary>
        /// <remarks>
        /// [{"op":"replace","path":"/name","value":"Robert"}]
        /// </remarks>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="customer">Customer info to be replaced and the new value</param>
        [HttpPatch("{customerId}")]
        public void Update(int customerId, [FromBody] JsonPatchDocument customer) => _customerService.UpdateCustomer(customerId, customer);
    }
}
