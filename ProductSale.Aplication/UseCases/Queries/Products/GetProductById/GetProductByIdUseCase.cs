using ProductSale.Domain.Repositories;
using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Queries.Products.GetProductById
{
    public sealed class GetProductByIdUseCase : IUseCase<int, UseCaseResult<GetProductByIdOutput>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<UseCaseResult<GetProductByIdOutput>> Execute(int input = 0)
        {
            Product product = _productRepository.GetProductById(input);

            var output = new GetProductByIdOutput(product);

            return Task.FromResult(new UseCaseResult<GetProductByIdOutput>(output, true));
        }
    }
}
