using Microsoft.AspNetCore.JsonPatch;
using ProductSale.DTOs.Orders;

namespace ProductSale.App.Services.OrderService
{
    public interface IOrderService
    {
        void CreateOrder(InputOrderDto inputOrderDto);
        void UpdateOrder(int id, JsonPatchDocument order);
        OutputOrderDto GetOrderById(int id);
    }
}
