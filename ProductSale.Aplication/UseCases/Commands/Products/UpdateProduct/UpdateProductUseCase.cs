using ProductSale.Domain.Repositories;
using ProductSale.Domain.Entities;

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
            if (input is null)
            {
                throw new ArgumentNullException("The sent informations are invalid", nameof(UpdateProductInput));
            }

            Product product = input.ToEntity();

            Product productUpdated = _productRepository.UpdateProduct(input.Id, product);

            var output = new UpdateProductOutput(product);

            return Task.FromResult(new UseCaseResult<UpdateProductOutput>(output, true, "Product updated"));
        }
    }
}
