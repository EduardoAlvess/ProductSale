using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using ProductSale.App.Services.OrderService;
using ProductSale.DTOs.Orders;

namespace ProductSale.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public void Create(InputOrderDto orderDto) => _orderService.CreateOrder(orderDto);

        [HttpGet("{orderId}")]
        public OutputOrderDto GetById(int orderId) => _orderService.GetOrderById(orderId);

        [HttpGet]
        public List<OutputOrderDto> Get() => _orderService.GetAllOrders();

        [HttpPatch("{orderId}")]
        public void Update(int orderId, [FromBody] JsonPatchDocument order) => _orderService.UpdateOrder(orderId, order);
    }
}
