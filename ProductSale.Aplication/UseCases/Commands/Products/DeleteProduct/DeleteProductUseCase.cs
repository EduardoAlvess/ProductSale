using ProductSale.Domain.Repositories;

namespace ProductSale.Aplication.UseCases.Commands.Products.DeleteProduct
{
    public sealed class DeleteProductUseCase : IUseCase<int, UseCaseResult<NoOutput>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<UseCaseResult<NoOutput>> Execute(int input = 0)
        {
            _productRepository.DeleteProduct(input);

            var output = new NoOutput();

            return Task.FromResult(new UseCaseResult<NoOutput>(output, true, "Product deleted"));
        }
    }
}
