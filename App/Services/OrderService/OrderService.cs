using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using ProductSale.Core.Exceptions;
using ProductSale.Core.Exceptions.OrderExceptions;
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
                Profit = CalculateOrderProfit(inputOrderDto.Amount, inputOrderDto.OrderProducts)
            };

            RemoveStock(inputOrderDto.OrderProducts);

            _db.Orders.Add(order);

            _db.Save();
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

            RecalculateOrderProfitIfNeeded(id, inputOrder.Operations);

            _db.Save();
        }

        public void UpdateOrderProducts(int orderId, int productId, JsonPatchDocument orderProducts)
        {
            CheckProductQuantity(productId, orderProducts.Operations);

            OrderProduct orderProduct = _db.OrderProduct.FirstOrDefault(op => op.OrderId == orderId && op.ProductId == productId);

            orderProducts.ApplyTo(orderProduct);

            RecalculateOrderProfitIfNeeded(orderId, orderProducts.Operations);

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

        private double CalculateOrderProfit(double amount, ICollection<OrderProduct> orderProducts)
        {
            double profit = amount;

            foreach (var orderProduct in orderProducts)
            {
                var productionCost = _db.Products.First(o => o.Id == orderProduct.ProductId).ProductionCost;

                double totalProductCost = productionCost * orderProduct.Quantity;

                profit -= totalProductCost;
            }

            return profit;
        }

        private void CheckProductQuantity(int productId, List<Operation> operations)
        {
            foreach (var operation in operations)
            {
                if (operation.path.ToLower() == "/quantity")
                {
                    if (Convert.ToInt32(operation.value) < 0)
                        throw new QuantityLowerThanZeroException("The quantity of this product in order can't be less than 0");

                    int amountInStock = _db.Products.Single(p => p.Id == productId).AmountInStock;

                    if (Convert.ToInt32(operation.value) > amountInStock)
                        throw new HigherThanStockException("The quantity of this product in order is higher than the amount in stock");
                }
            }
        }

        private void RecalculateOrderProfitIfNeeded(int orderId, List<Operation> operations)
        {
            foreach (var operation in operations)
            {
                if (operation.path.ToLower() == "/quantity" || operation.path.ToLower() == "/amount")
                {
                    Order order = _db.Orders.Single(o => o.Id == orderId);

                    var orderProducts = _db.OrderProduct.Where(op => op.OrderId == orderId).ToList();

                    var newOrderProfit = CalculateOrderProfit(order.Amount, orderProducts);

                    order.Profit = newOrderProfit;
                }
            }
        }
    }
}
