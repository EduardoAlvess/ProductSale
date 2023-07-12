using ProductSale.DTOs.Product;

namespace ProductSale.App.Services.ProductService
{
    public interface IProductService
    {
        void CreateProduct(InputProductDto inputProductDto);
        void UpdateProduct(InputProductDto inputProductDto);
        void DeleteProduct(InputProductDto inputProductDto);
        List<OutputProductDto> GetAllProducts();
        OutputProductDto GetProductById(int id);
    }
}
