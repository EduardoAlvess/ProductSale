using ProductSale.DTOs.Product;
using ProductSale.Infra.DB;
using ProductSale.Core.Models;

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
        }

        public void DeleteProduct(InputProductDto inputProductDto)
        {
            throw new NotImplementedException();
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
