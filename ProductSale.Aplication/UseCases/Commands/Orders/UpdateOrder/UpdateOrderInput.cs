using ProductSale.Domain.Entities;
using ProductSale.Domain.Enums;

namespace ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrder
{
    public record UpdateOrderInput
    {
        public int Id { get; private set; }
        public Stage Stage { get; private set; }
        public double Amount { get; private set; }
        public double Profit { get; private set; }

        public UpdateOrderInput(int id, Stage stage, double amount, double profit)
        {
            Id = id;
            Stage = stage;
            Amount = amount;
            Profit = profit;
        }

        public Order ToEntity()
        {
            return new Order(Stage, Amount, Profit);
        }
    }
}