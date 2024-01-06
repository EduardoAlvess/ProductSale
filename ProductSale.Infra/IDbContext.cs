using Microsoft.EntityFrameworkCore;
using ProductSale.Domain.Entities;

namespace ProductSale.Infra
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<OrderProduct> OrderProduct { get; set; }
        void Save();
    }
}
