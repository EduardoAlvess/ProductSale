using Microsoft.EntityFrameworkCore;
using ProductSale.Domain.Entities;
using ProductSale.Infra;

namespace ProductSale.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext _context;

        public ProductRepository(IDbContext context)
        {
            _context = context;
        }

        public int CreateProduct(Product product)
        {
            _context.Products.Add(product);

            _context.Save();

            return product.Id;
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);

            product.Delete();

            _context.Save();
        }

        public List<Product> GetAllOrderProductsByOrderId(int orderId)
        {
            var orderProducts = _context.OrderProduct.Where(x => x.OrderId == orderId).ToList();

            List<Product> products = new();

            foreach (var orderProduct in orderProducts)
            {
                var product = _context.Products.SingleOrDefault(x => x.Id == orderProduct.ProductId);
                products.Add(product);
            }

            return products;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.AsNoTracking().ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            var productToUpdate = _context.Products.SingleOrDefault(x => x.Id == id);

            productToUpdate.Update(product);

            _context.Save();

            return productToUpdate;
        }
    }
}
