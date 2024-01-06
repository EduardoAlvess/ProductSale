using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Commands.Products.UpdateProduct
{
    public record UpdateProductInput
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Value { get; private set; }
        public int AmountInStock { get; private set; }
        public string Description { get; private set; }
        public double ProductionCost { get; private set; }

        public UpdateProductInput(string name, double value, int amountInStock, string description, double productionCost)
        {
            Name = name;
            Value = value;
            AmountInStock = amountInStock;
            Description = description;
            ProductionCost = productionCost;
        }

        public Product ToEntity()
        {
            return new Product(Name, Value, AmountInStock, Description, ProductionCost);
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}