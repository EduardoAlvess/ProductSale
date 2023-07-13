using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ProductSale.App.Services.CustomerService;
using ProductSale.App.Services.ProductService;
using ProductSale.DTOs.Customers;
using ProductSale.DTOs.Products;
using ProductSale.Infra.DB;

namespace ProductSale
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddNewtonsoftJson()
                .AddFluentValidation();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<IDbContext, DataContext>(dbContextOptions =>
            dbContextOptions.UseMySql("Server=mysql744.umbler.com;Port=41890;Database=testeeduardo;Uid=testeeduardo123;Pwd=testeeduardo12345;", new MySqlServerVersion(new Version(5, 6, 0)))
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors());

            builder.Services.AddValidatorsFromAssemblyContaining<InputProductDto>();
            builder.Services.AddValidatorsFromAssemblyContaining<InputCustomerDto>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}