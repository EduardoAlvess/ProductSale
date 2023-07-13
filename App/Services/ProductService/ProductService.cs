using ProductSale.DTOs.Product;
using ProductSale.Infra.DB;
using ProductSale.Core.Models;
using ProductSale.Core.Exceptions.ProductExceptions;
using Microsoft.AspNetCore.JsonPatch;

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
                Product product = _db.Products.Single(p => p.Id == id);

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
            List<OutputProductDto> productDtos = new();

            List<Product> products = _db.Products.ToList();

            foreach(var product in products)
            {
                OutputProductDto productDto = new()
                {
                    Name = product.Name,
                    Value = product.Value,
                    Description = product.Description,
                    AmountInStock = product.AmountInStock,
                    ProductionCost = product.ProductionCost
                };

                productDtos.Add(productDto);
            }

            return productDtos;
        }

        public OutputProductDto GetProductById(int id)
        {
            try
            {
                Product product = _db.Products.Single(p => p.Id == id);

                OutputProductDto productDto = new()
                {
                    Name = product.Name,
                    Value = product.Value,
                    Description = product.Description,
                    AmountInStock = product.AmountInStock,
                    ProductionCost = product.ProductionCost
                };

                return productDto;
            }
            catch (InvalidOperationException ex)
            {
                throw new ProductNotFoundException("Can't find a product with this id");
            }
        }

        public void UpdateProduct(int id, JsonPatchDocument inputProduct)
        {
            foreach(var operation in inputProduct.Operations)
            {
                if(String.IsNullOrEmpty(operation.op))
                    throw new ProductUpdateOperationRequiredException("Operation is required");
                if(String.IsNullOrEmpty(operation.path))
                    throw new ProductUpdatePathRequiredException("Path is required");
                if (String.IsNullOrEmpty(operation.value.ToString()))
                    throw new ProductUpdateValueRequiredException("Value is required");
            }

            Product product = _db.Products.Single(p => p.Id == id);

            inputProduct.ApplyTo(product);

            _db.Save();
        }
    }
}
