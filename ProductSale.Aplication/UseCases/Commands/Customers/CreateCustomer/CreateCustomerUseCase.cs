using ProductSale.Domain.Entities;
using ProductSale.Domain.Repositories;

namespace ProductSale.Aplication.UseCases.Commands.Customers.CreateCustomer
{
    public sealed class CreateCustomerUseCase : IUseCase<CreateCustomerInput, UseCaseResult<int>>
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<UseCaseResult<int>> Execute(CreateCustomerInput input = null)
        {
            Customer customer = new(input.Name, input.Phone, input.Register);

            int createdCustomerId = _customerRepository.CreateCustomer(customer);

            return Task.FromResult(new UseCaseResult<int>(createdCustomerId, true, "Customer created"));
        }
    }
}
