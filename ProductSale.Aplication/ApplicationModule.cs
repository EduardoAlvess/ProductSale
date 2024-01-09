using Microsoft.Extensions.DependencyInjection;
using ProductSale.Application.Services;
using ProductSale.Aplication.UseCases;
using ProductSale.Aplication.UseCases.Commands.Customers.CreateCustomer;
using ProductSale.Aplication.UseCases.Commands.Customers.UpdateCustomer;
using ProductSale.Aplication.UseCases.Commands.Orders.CreateOrder;
using ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrder;
using ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrderProducts;
using ProductSale.Aplication.UseCases.Commands.Products.CreateProduct;
using ProductSale.Aplication.UseCases.Commands.Products.DeleteProduct;
using ProductSale.Aplication.UseCases.Commands.Products.UpdateProduct;
using ProductSale.Aplication.UseCases.Queries.Customers.GetAllCustomers;
using ProductSale.Aplication.UseCases.Queries.Customers.GetCustomerById;
using ProductSale.Aplication.UseCases.Queries.Orders.GetOrderById;
using ProductSale.Aplication.UseCases.Queries.Products.GetAllProducts;
using ProductSale.Aplication.UseCases.Queries.Products.GetProductById;

namespace ProductSale.Aplication
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddUseCases()
                    .AddServices();

            return services;
        }

        private static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            //Commands
            services.AddScoped<IUseCase<UpdateCustomerInput, UseCaseResult<UpdateCustomerOutput>>, UpdateCustomerUseCase>();
            services.AddScoped<IUseCase<CreateCustomerInput, UseCaseResult<int>>, CreateCustomerUseCase>();

            services.AddScoped<IUseCase<UpdateOrderProductsInput, UseCaseResult<UpdateOrderProductsOutput>>, UpdateOrderProductsUseCase>();
            services.AddScoped<IUseCase<UpdateOrderInput, UseCaseResult<UpdateOrderOutput>>, UpdateOrderUseCase>();
            services.AddScoped<IUseCase<CreateOrderInput, UseCaseResult<int>>, CreateOrderUseCase>();

            services.AddScoped<IUseCase<UpdateProductInput, UseCaseResult<UpdateProductOutput>>, UpdateProductUseCase>();
            services.AddScoped<IUseCase<CreateProductInput, UseCaseResult<int>>, CreateProductUseCase>();
            services.AddScoped<IUseCase<int, UseCaseResult<NoOutput>>, DeleteProductUseCase>();

            //Queries
            services.AddScoped<IUseCase<NoInput, UseCaseResult<GetAllCustomersOutput>>, GetAllCustomersUseCase>();
            services.AddScoped<IUseCase<int, UseCaseResult<GetCustomerByIdOutput>>, GetCustomerByIdUseCase>();

            services.AddScoped<IUseCase<int, UseCaseResult<GetOrderByIdOutput>>, GetOrderByIdUseCase>();

            services.AddScoped<IUseCase<NoInput, UseCaseResult<GetAllProductsOutput>>, GetAllProductsUseCase>();
            services.AddScoped<IUseCase<int, UseCaseResult<GetProductByIdOutput>>, GetProductByIdUseCase>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
