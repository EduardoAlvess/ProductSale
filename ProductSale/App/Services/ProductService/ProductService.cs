using ProductSale.Infra.DB;
using ProductSale.Core.Models;
using ProductSale.Infra.Cache;
using ProductSale.DTOs.Products;
using ProductSale.Core.Exceptions;
using Microsoft.AspNetCore.JsonPatch;

namespace ProductSale.App.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IDbContext _db;
        private readonly ICacheProvider _cache;

        public ProductService(IDbContext dbContext, ICacheProvider cache)
        {
            _db = dbContext;
            _cache = cache;
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

            _cache.DeleteCache("products");

            _db.Save();
        }

        public void DeleteProduct(int id)
        {
            try
            {
                Product product = _db.Products.Single(p => p.Id == id);

                product.isDeleted = true;

                _cache.DeleteCache("products");

                _db.Save();
            }
            catch(InvalidOperationException ex)
            {
                throw new NotFoundException("Can't find a product with this id");
            }
        }

        public List<OutputProductDto> GetAllProducts()
        {
            List<OutputProductDto> productDtos = new();

            List<Product> products;

            var cacheData = _cache.Get<List<Product>>("products");

            if (cacheData is not null && cacheData.Count() > 0)
                products = cacheData;
            else
            {
                products = _db.Products.ToList();
                _cache.Set("products", products);
            }

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
                throw new NotFoundException("Can't find a product with this id");
            }
        }

        public void UpdateProduct(int id, JsonPatchDocument inputProduct)
        {
            try
            {
                Product product = _db.Products.Single(p => p.Id == id);

                inputProduct.ApplyTo(product);

                _cache.DeleteCache("products");

                _db.Save();
            }
            catch(Exception e)
            {
                throw new NotFoundException("Product not found");
            }
        }
    }
}
