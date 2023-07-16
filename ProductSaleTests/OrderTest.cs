using ProductSale.App.Services.OrderService;
using ProductSale.DTOs.Orders;
using ProductSale.Core.Enums;

namespace ProductSaleTest
{
    public class OrderTest
    {
        private readonly IOrderService _orderService;
        private readonly IDbContext _db;

        public OrderTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            _db = new DataContext(optionsBuilder.Options);

            PopulateTable();

            _orderService = new OrderService(_db);
        }

        [Fact]
        public void CreateOrder_ShouldCreate()
        {
            var orderProducts = new List<OrderProduct>()
            {
                new OrderProduct()
                {
                    ProductId = 1,
                    Quantity = 2
                }
            };

            InputOrderDto inputOrderDto = new()
            {
                Amount = 200,
                CustomerId = 1,
                Stage = Stage.Preparation,
                OrderProducts = orderProducts
            };

            _orderService.CreateOrder(inputOrderDto);

            var order = _db.Orders.First(p => p.Id == 2);

            Assert.Equal(200, order.Amount);
            Assert.Equal(1, order.CustomerId);
            Assert.Equal(Stage.Preparation, order.Stage);
            Assert.Equal(orderProducts, order.OrderProducts);
        }

        [Fact]
        public void GetOrderById_ShouldReturnOrder()
        {
            var order = _orderService.GetOrderById(1);

            Assert.NotNull(order);
        }

        [Fact]
        public void UpdateOrder_ShouldUpdate()
        {
            var jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/amount", 150);

            _orderService.UpdateOrder(1, jsonPatch);

            Assert.Equal(150, _db.Orders.First(p => p.Id == 1).Amount);
        }

        [Fact]
        public void UpdateOrderProduct_ShouldUpdate()
        {
            var jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/quantity", 3);

            _orderService.UpdateOrderProducts(1, 1, jsonPatch);

            Assert.Equal(3, _db.OrderProduct.First(p => p.Id == 1 && p.ProductId == 1).Quantity);
        }

        private void PopulateTable()
        {
            Product product = new()
            {
                Value = 20,
                Name = "Table",
                AmountInStock = 7,
                ProductionCost = 10,
                Description = "A Table"
            };

            Customer customer = new()
            {
                Name = "Eduardo",
                Register = "673.608.520-72",
                Phone = "51 92202-2979",
            };

            var orderProducts = new List<OrderProduct>()
            {
                new OrderProduct()
                {
                    ProductId = 1,
                    Quantity = 5
                }
            };

            Order order = new()
            {
                Amount = 250,
                CustomerId = 1,
                Stage = Stage.Preparation,
                OrderProducts = orderProducts
            };

            _db.Customers.Add(customer);
            _db.Products.Add(product);
            _db.Orders.Add(order);

            _db.Save();
        }
    }
}