using ProductSale.Domain.Repositories;

namespace ProductSale.Aplication.UseCases.Queries.Customers.GetAllCustomers
{
    public sealed class GetAllCustomersUseCase : IUseCase<NoInput, UseCaseResult<GetAllCustomersOutput>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<UseCaseResult<GetAllCustomersOutput>> Execute(NoInput input = null)
        {
            var customers = _customerRepository.GetAllCustomers();

            var output = new GetAllCustomersOutput(customers);

            return Task.FromResult(new UseCaseResult<GetAllCustomersOutput>(output, true));
        }
    }
}
