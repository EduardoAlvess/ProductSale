using Microsoft.Extensions.DependencyInjection;
using ProductSale.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ProductSale.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddDbContext<IDbContext, DataContext>(dbContextOptions =>
            dbContextOptions.UseMySql("Server=localhost;Port=3306;Database=productsale;Uid=root;Pwd=12345;", new MySqlServerVersion(new Version(5, 6, 0)))
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors());

            return services;
        }

        private static IServiceCollection AddRepositories (this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
