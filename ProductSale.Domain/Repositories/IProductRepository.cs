using ProductSale.Domain.Entities;

namespace ProductSale.Domain.Repositories
{
    public interface IProductRepository
    {
        Product UpdateProduct(int id, Product product);
        int CreateProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void DeleteProduct(int id);
    }
}
