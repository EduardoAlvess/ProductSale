using ProductSale.Domain.Repositories;

namespace ProductSale.Aplication.UseCases.Queries.Products.GetAllProducts
{
    public sealed class GetAllProductsUseCase : IUseCase<NoInput, UseCaseResult<GetAllProductsOutput>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<UseCaseResult<GetAllProductsOutput>> Execute(NoInput input = null)
        {
            var products = _productRepository.GetAllProducts();

            var output = new GetAllProductsOutput(products);

            return Task.FromResult(new UseCaseResult<GetAllProductsOutput>(output, true));
        }
    }
}
