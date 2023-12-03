using Microsoft.Extensions.DependencyInjection;
using ProductSale.Domain.Repositories;

namespace ProductSale.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services)
        {
            services.AddRepositories();

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
