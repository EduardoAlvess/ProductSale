using Microsoft.AspNetCore.JsonPatch;
using ProductSale.Core.Exceptions;
using ProductSale.Core.Models;
using ProductSale.DTOs.OrderProducts;
using ProductSale.DTOs.Orders;
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

        public OutputOrderDto GetOrderById(int id)
        {
            try
            {
                Order order = _db.Orders.Single(p => p.Id == id);

                var orderProducts = _db.OrderProduct.Where(op => op.OrderId == order.Id).ToList();

                List<OutputOrderProductsDto> outputOrderProducts = new();

                foreach(var orderProduct in orderProducts)
                {
                    OutputOrderProductsDto outputOrderProduct = new()
                    {
                        ProductId = orderProduct.ProductId,
                        Quantity = orderProduct.Quantity
                    };
                    outputOrderProducts.Add(outputOrderProduct);
                }

                OutputOrderDto orderDto = new()
                {
                    Stage = order.Stage,
                    Amount = order.Amount,
                    Profit = order.Profit,
                    CustomerId = order.CustomerId,
                    OrderProducts = outputOrderProducts
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
            Order order = _db.Orders.Single(p => p.Id == id);

            inputOrder.ApplyTo(order);

            _db.Save();
        }

        public void UpdateOrderProducts(int orderId, int productId, JsonPatchDocument orderProducts)
        {
            OrderProduct orderProduct = _db.OrderProduct.FirstOrDefault(op => op.OrderId == orderId && op.ProductId == productId);

            orderProducts.ApplyTo(orderProduct);

            _db.Save();
        }
    }
}
