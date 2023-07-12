using Microsoft.EntityFrameworkCore;
using ProductSale.Core.Models;

namespace ProductSale.Infra.DB
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Customer> Customers { get; set; }
    }
}
