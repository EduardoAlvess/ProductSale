using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Commands.Products.UpdateProduct
{
    public record UpdateProductOutput
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Value { get; private set; }
        public bool IsDeleted { get; private set; }
        public int ValueInStock { get; private set; }
        public string Description { get; private set; }
        public double ProductionCost { get; private set; }

        public UpdateProductOutput(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Value = product.Value;
            IsDeleted = product.IsDeleted;
            Description = product.Description;
            ValueInStock = product.AmountInStock;
            ProductionCost = product.ProductionCost;
        }
    }
}