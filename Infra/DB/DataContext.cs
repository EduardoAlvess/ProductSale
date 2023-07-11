using Microsoft.EntityFrameworkCore;
using ProductSale.Core.Models;

namespace ProductSale.Infra.DB
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
                : base(options)
        {
        }
    }
}
