using ProductSale.Aplication.UseCases.Commands.Orders.CreateOrder;
using ProductSale.Domain.Entities;

namespace ProductSale.Application.Services
{
    public interface IOrderService
    {
        double RecalculateProfit(double value, Order order);
        double CalculateProfit(CreateOrderInput order);
    }
}
