using ProductSale.Domain.Repositories;

namespace ProductSale.Aplication.UseCases.Queries.Customers.GetCustomerById
{
    public sealed class GetCustomerByIdUseCase : IUseCase<int, UseCaseResult<GetCustomerByIdOutput>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<UseCaseResult<GetCustomerByIdOutput>> Execute(int input)
        {
            var customer = _customerRepository.GetCustomerById(input);

            var output = new GetCustomerByIdOutput(customer);

            return Task.FromResult(new UseCaseResult<GetCustomerByIdOutput>(output, true));
        }
    }
}
