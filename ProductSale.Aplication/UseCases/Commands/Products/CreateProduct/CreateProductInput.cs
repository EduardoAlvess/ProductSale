using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Commands.Products.CreateProduct
{
    public record CreateProductInput
    {
        public string Name { get; private set; }
        public double Value { get; private set; }
        public int AmountInStock { get; private set; }
        public string Description { get; private set; }
        public double ProductionCost { get; private set; }

        public CreateProductInput(string name, double value, int amountInStock, string description, double productionCost)
        {
            Name = name;
            Value = value;
            Description = description;
            AmountInStock = amountInStock;
            ProductionCost = productionCost;
        }

        public Product ToEntity()
        {
            return new Product(Name, Value, AmountInStock, Description, ProductionCost);
        }
    }
}
