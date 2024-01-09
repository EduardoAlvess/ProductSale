using ProductSale.Aplication.UseCases.Commands.Orders.CreateOrder;
using ProductSale.Domain.Entities;
using ProductSale.Domain.Repositories;

namespace ProductSale.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public double CalculateProfit(CreateOrderInput order)
        {
            double totalProductsProdCost = 0;

            foreach (var orderProduct in order.OrderProducts)
            {
                var productProdCost = _unitOfWork.ProductRepository
                                                    .GetProductById(orderProduct.ProductId)
                                                    .ProductionCost;

                var totalCost = orderProduct.Quantity * productProdCost;

                totalProductsProdCost += totalCost;
            }

            double profit = order.Value - totalProductsProdCost;

            return profit;
        }

        public double RecalculateProfit(double value, Order order)
        {
            double totalProductsProdCost = 0;

            foreach (var orderProduct in order.OrderProducts)
            {
                var productProdCost = _unitOfWork.ProductRepository
                                                    .GetProductById(orderProduct.ProductId)
                                                    .ProductionCost;

                var totalCost = orderProduct.Quantity * productProdCost;

                totalProductsProdCost += totalCost;
            }

            double profit = value - totalProductsProdCost;

            return profit;
        }
    }
}
