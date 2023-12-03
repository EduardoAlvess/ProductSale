using ProductSale.Domain.Entities;
using ProductSale.Domain.Repositories;

namespace ProductSale.Aplication.UseCases.Commands.Customers.UpdateCustomer
{
    public sealed class UpdateCustomerUseCase : IUseCase<UpdateCustomerInput, UseCaseResult<UpdateCustomerOutput>>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<UseCaseResult<UpdateCustomerOutput>> Execute(UpdateCustomerInput input = null)
        {
            Customer customer = new(input.Name, input.Phone, input.Register);

            Customer updatedCustomer = _customerRepository.UpdateCustomer(input.Id, customer);

            var output = new UpdateCustomerOutput(updatedCustomer);

            return Task.FromResult(new UseCaseResult<UpdateCustomerOutput>(output, true, "Customer updated"));
        }
    }
}
