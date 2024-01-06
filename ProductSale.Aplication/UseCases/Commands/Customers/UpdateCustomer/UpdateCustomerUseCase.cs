using ProductSale.Domain.Repositories;
using ProductSale.Domain.Entities;

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
            if (input is null)
            {
                throw new ArgumentNullException("The sent informations are invalid", nameof(UpdateCustomerInput));
            }

            Customer customer = input.ToEntity();

            Customer updatedCustomer = _customerRepository.UpdateCustomer(input.Id, customer);

            var output = new UpdateCustomerOutput(updatedCustomer);

            return Task.FromResult(new UseCaseResult<UpdateCustomerOutput>(output, true, "Customer updated"));
        }
    }
}
