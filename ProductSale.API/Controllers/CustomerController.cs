using ProductSale.Aplication.UseCases.Commands.Customers.CreateCustomer;
using ProductSale.Aplication.UseCases.Commands.Customers.UpdateCustomer;
using ProductSale.Aplication.UseCases.Queries.Customers.GetAllCustomers;
using ProductSale.Aplication.UseCases.Queries.Customers.GetCustomerById;
using ProductSale.Aplication.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ProductSale.API.Controllers
{
    public class CustomerController : Controller
    {
        [HttpPost]
        [Route("/CreateCustomer")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerInput createCustomerInput, [FromServices] IUseCase<CreateCustomerInput, UseCaseResult<int>> useCase)
        {
            var output = await useCase.Execute(createCustomerInput);

            return Ok(output);
        }

        [HttpPut]
        [Route("/UpdateCustomer/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerInput updateCustomerInput, [FromServices] IUseCase<UpdateCustomerInput, UseCaseResult<UpdateCustomerOutput>> useCase)
        {
            updateCustomerInput.SetId(id);

            var output = await useCase.Execute(updateCustomerInput);

            return Ok(output);
        }

        [HttpGet]
        [Route("/GetCustomerById/{id}")]
        public async Task<IActionResult> GetById(int id, [FromServices] IUseCase<int, UseCaseResult<GetCustomerByIdOutput>> useCase)
        {
            var output = await useCase.Execute(id);

            return Ok(output);
        }

        [HttpGet]
        [Route("/GetAllCustomers")]
        public async Task<IActionResult> GetAll([FromServices] IUseCase<NoInput, UseCaseResult<GetAllCustomersOutput>> useCase)
        {
            var output = await useCase.Execute();

            return Ok(output);
        }
    }
}
