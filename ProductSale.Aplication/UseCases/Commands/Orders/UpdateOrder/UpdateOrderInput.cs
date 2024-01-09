using ProductSale.Domain.Entities;
using ProductSale.Domain.Enums;

namespace ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrder
{
    public record UpdateOrderInput
    {
        public int Id { get; private set; }
        public Stage Stage { get; private set; }
        public double Value { get; private set; }
        public double Profit { get; private set; }

        public UpdateOrderInput(Stage stage, double value)
        {
            Stage = stage;
            Value = value;
        }

        public Order ToEntity()
        {
            return new Order(Stage, Value, Profit);
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}