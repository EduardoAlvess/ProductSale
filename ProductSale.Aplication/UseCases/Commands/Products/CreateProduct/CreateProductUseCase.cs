using ProductSale.Domain.Entities;
using ProductSale.Domain.Repositories;

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
            Product product = new(input.Name, input.Value, input.AmountInStock, input.Description, input.ProductionCost);

            int createdProductId = _productRepository.CreateProduct(product);

            return Task.FromResult(new UseCaseResult<int>(createdProductId, true, "Product created"));
        }
    }
}
