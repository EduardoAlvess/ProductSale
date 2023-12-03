using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Queries.Products.GetProductById
{
    public record GetProductByIdOutput
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Value { get; private set; }
        public bool IsDeleted { get; private set; }
        public int AmountInStock { get; private set; }
        public string Description { get; private set; }
        public double ProductionCost { get; private set; }

        public GetProductByIdOutput(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Value = product.Value;
            IsDeleted  = product.IsDeleted;
            Description = product.Description;
            AmountInStock = product.AmountInStock;
            ProductionCost = product.ProductionCost;
        }
    }
}