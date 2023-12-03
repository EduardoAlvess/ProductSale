using ProductSale.Domain.Repositories;
using ProductSale.Domain.Entities;

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
            Customer customer = input.ToEntity();

            int createdCustomerId = _customerRepository.CreateCustomer(customer);

            return Task.FromResult(new UseCaseResult<int>(createdCustomerId, true, "Customer created"));
        }
    }
}
