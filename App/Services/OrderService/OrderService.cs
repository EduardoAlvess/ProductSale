using Microsoft.AspNetCore.JsonPatch;
using ProductSale.Core.Exceptions;
using ProductSale.Core.Models;
using ProductSale.DTOs.Orders;
using ProductSale.DTOs.Products;
using ProductSale.Infra.DB;

namespace ProductSale.App.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IDbContext _db;

        public OrderService(IDbContext dbContext)
        {
            _db = dbContext;
        }

        public void CreateOrder(InputOrderDto inputOrderDto)
        {
            Order order = new Order()
            {
                Stage = inputOrderDto.Stage,
                Amount = inputOrderDto.Amount,
                CustomerId = inputOrderDto.CustomerId,
                OrderProducts = inputOrderDto.OrderProducts,
                Profit = CalculateOrderProfit(inputOrderDto.OrderProducts)
            };

            RemoveStock(inputOrderDto.OrderProducts);

            _db.Orders.Add(order);

            _db.Save();
        }

        private void RemoveStock(ICollection<OrderProduct> orderProducts)
        {
            foreach (var orderProduct in orderProducts)
            {
                var product = _db.Products.First(p => p.Id == orderProduct.ProductId);

                product.AmountInStock -= orderProduct.Quantity;
            }
        }

        private double CalculateOrderProfit(ICollection<OrderProduct> orderProducts)
        {
            double profit = 0;

            foreach (var orderProduct in orderProducts)
            {
                var product = _db.Products.First(o => o.Id == orderProduct.ProductId);

                double productProfit = (product.Value - product.ProductionCost) * orderProduct.Quantity;

                profit += productProfit;
            }

            return profit;
        }

        public List<OutputOrderDto> GetAllOrders()
        {
            List<OutputOrderDto> orderDtos = new();

            List<Order> orders = _db.Orders.ToList();

            //foreach(var order in orders)
            //{
            //    List<Order> order = _db.Orders.Where(o => o.CustomerId == order.Id).ToList();

            //    OutputOrderDto orderDto = new()
            //    {
            //        Name = order.Name,
            //        Phone = order.Phone,
            //        Register = order.Register,
            //        Orders = order
            //    };

            //    orderDtos.Add(orderDto);
            //}

            return orderDtos;
        }

        public OutputOrderDto GetOrderById(int id)
        {
            try
            {
                Order order = _db.Orders.Single(p => p.Id == id);

                string customerName = _db.Customers.First(c => c.Id == order.CustomerId).Name;

                List<OutputProductDto> productDtos = new();  

                //foreach(var product in order.Products)
                //{
                //    OutputProductDto productDto = new()
                //    {
                //        Name = product.Name,
                //        Value = product.Value,
                //        Description = product.Description,
                //        AmountInStock = product.AmountInStock,
                //        ProductionCost = product.ProductionCost
                //    };

                //    productDtos.Add(productDto);
                //}

                OutputOrderDto orderDto = new()
                {
                    Stage = order.Stage,
                    Amount = order.Amount,
                    Profit = order.Profit,
                    Products = productDtos,
                    CustomerName = customerName
                };

                return orderDto;
            }
            catch (InvalidOperationException ex)
            {
                throw new NotFoundException("Can't find a order with this id");
            }
        }

        public void UpdateOrder(int id, JsonPatchDocument inputOrder)
        {
            foreach(var operation in inputOrder.Operations)
            {
                if(String.IsNullOrEmpty(operation.op))
                    throw new UpdateOperationRequiredException("Operation is required");
                if(String.IsNullOrEmpty(operation.path))
                    throw new UpdatePathRequiredException("Path is required");
                if (String.IsNullOrEmpty(operation.value.ToString()))
                    throw new UpdateValueRequiredException("Value is required");
            }

            Order order = _db.Orders.Single(p => p.Id == id);

            inputOrder.ApplyTo(order);

            _db.Save();
        }
    }
}
