using Microsoft.AspNetCore.JsonPatch;
using ProductSale.DTOs.Product;

namespace ProductSale.App.Services.ProductService
{
    public interface IProductService
    {
        void CreateProduct(InputProductDto inputProductDto);
        void UpdateProduct(int id, JsonPatchDocument product);
        void DeleteProduct(int id);
        List<OutputProductDto> GetAllProducts();
        OutputProductDto GetProductById(int id);
    }
}
