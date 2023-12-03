using ProductSale.Domain.Entities;
using ProductSale.Domain.Repositories;

namespace ProductSale.Aplication.UseCases.Commands.Products.UpdateProduct
{
    public sealed class UpdateProductUseCase : IUseCase<UpdateProductInput, UseCaseResult<UpdateProductOutput>>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<UseCaseResult<UpdateProductOutput>> Execute(UpdateProductInput input = null)
        {
            Product product = new(input.Name, input.Value, input.AmountInStock, input.Description, input.ProductionCost);

            Product productUpdated = _productRepository.UpdateProduct(input.Id, product);

            var output = new UpdateProductOutput(product);

            return Task.FromResult(new UseCaseResult<UpdateProductOutput>(output, true, "Product updated"));
        }
    }
}
