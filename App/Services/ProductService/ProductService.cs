using ProductSale.DTOs.Product;
using ProductSale.Infra.DB;
using ProductSale.Core.Models;
using ProductSale.Core.Exceptions.ProductExceptions;

namespace ProductSale.App.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IDbContext _db;

        public ProductService(IDbContext dbContext)
        {
            _db = dbContext;
        }

        public void CreateProduct(InputProductDto inputProductDto)
        {
            Product product = new Product()
            {
                Name = inputProductDto.Name,
                Value = inputProductDto.Value,
                AmountInStock = inputProductDto.AmountInStock,
                Description = inputProductDto.Description,
                ProductionCost = inputProductDto.ProductionCost
            };

            _db.Products.Add(product);

            _db.Save();
        }

        public void DeleteProduct(int id)
        {
            try
            {
                var product = _db.Products.Single(p => p.Id == id);

                product.isDeleted = true;

                _db.Save();
            }
            catch(InvalidOperationException ex)
            {
                throw new ProductNotFoundException("Can't find a product with this id");
            }
        }

        public List<OutputProductDto> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public OutputProductDto GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(InputProductDto inputProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
