using Microsoft.EntityFrameworkCore;
using ProductSale.Domain.Entities;
using System.Reflection;

namespace ProductSale.Infra
{
    public class DataContext : DbContext, IDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
