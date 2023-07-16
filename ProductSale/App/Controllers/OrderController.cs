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


        /// <summary>
        /// Create a new order
        /// </summary>
        /// <remarks>
        /// {"stage":1,"amount":"150","customerId":1,"orderProducts":[{"productId":1,"quantity":10}]}
        /// </remarks>
        /// <param name="orderDto">Order infos</param>
        [HttpPost]
        public void Create(InputOrderDto orderDto) => _orderService.CreateOrder(orderDto);

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="orderId">Order identifier</param>
        /// <returns>Order infos</returns>
        [HttpGet("{orderId}")]
        public OutputOrderDto GetById(int orderId) => _orderService.GetOrderById(orderId);

        /// <summary>
        /// Update order infos
        /// </summary>
        /// <remarks>
        /// [{"op":"replace","path":"/amount","value":140}]
        /// </remarks>
        /// <param name="orderId">Order identifier</param>
        /// <param name="order">Order info to be replaced and the new value</param>
        [HttpPatch("{orderId}")]
        public void Update(int orderId, [FromBody] JsonPatchDocument order) => _orderService.UpdateOrder(orderId, order);

        /// <summary>
        /// Update info of the products in a order
        /// </summary>
        /// <remarks>
        /// [{"op":"replace","path":"/quantity","value":1}]
        /// </remarks>
        /// <param name="orderId">Order identifier</param>
        /// <param name="productId">Product identifier</param>
        /// <param name="orderProduct">Product info to be replaced and the new value</param>
        [HttpPatch("{orderId}/product/{productId}")]
        public void UpdateOrderProducts(int orderId, int productId, [FromBody] JsonPatchDocument orderProduct) => _orderService.UpdateOrderProducts(orderId, productId, orderProduct);
    }
}
