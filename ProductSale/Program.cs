using FluentValidation;
using ProductSale.Infra.DB;
using ProductSale.DTOs.Orders;
using ProductSale.Infra.Cache;
using Microsoft.OpenApi.Models;
using ProductSale.DTOs.Products;
using ProductSale.DTOs.Customers;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using ProductSale.App.Services.OrderService;
using ProductSale.App.Services.ProductService;
using ProductSale.App.Services.CustomerService;

namespace ProductSale
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddNewtonsoftJson()
                                             .AddFluentValidation();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ProductSale",
                    Version = "v1"
                });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, "ProductSale.xml");
                x.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddDbContext<IDbContext, DataContext>(dbContextOptions =>
            dbContextOptions.UseMySql("Server=db;Port=3306;Database=productsale;Uid=productsale;Pwd=productsale;", new MySqlServerVersion(new Version(5, 6, 0)))
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors());

            builder.Services.AddValidatorsFromAssemblyContaining<InputOrderDto>();
            builder.Services.AddValidatorsFromAssemblyContaining<InputProductDto>();
            builder.Services.AddValidatorsFromAssemblyContaining<InputCustomerDto>();
            builder.Services.AddValidatorsFromAssemblyContaining<JsonPatchDocument>();

            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<ICacheProvider, CacheProvider>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}