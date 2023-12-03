using ProductSale.Domain.Repositories;
using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Commands.Products.CreateProduct
{
    internal class CreateProductUseCase : IUseCase<CreateProductInput, UseCaseResult<int>>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<UseCaseResult<int>> Execute(CreateProductInput input = null)
        {
            Product product = input.ToEntity();

            int createdProductId = _productRepository.CreateProduct(product);

            return Task.FromResult(new UseCaseResult<int>(createdProductId, true, "Product created"));
        }
    }
}
