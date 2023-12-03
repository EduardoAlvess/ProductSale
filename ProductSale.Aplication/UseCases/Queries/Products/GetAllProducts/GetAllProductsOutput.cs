using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Queries.Products.GetAllProducts
{
    public record GetAllProductsOutput
    {
        public List<ProductOutput> Products { get; set; }

        public GetAllProductsOutput(List<Product> products)
        {
            Products = products.Select(p =>
                        new ProductOutput(
                            p.Id,
                            p.Name,
                            p.Value,
                            p.IsDeleted,
                            p.Description,
                            p.AmountInStock,
                            p.ProductionCost)
                        ).ToList();
        }
    }

    public record ProductOutput
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Value { get; private set; }
        public bool IsDeleted { get; private set; }
        public int AmountInStock { get; private set; }
        public string Description { get; private set; }
        public double ProductionCost { get; private set; }

        public ProductOutput(int id, string name, double value, bool isDeleted, string description, int amountInStock, double productionCost)
        {
            Id = id;
            Name = name;
            Value = value;
            IsDeleted = isDeleted;
            Description = description;
            AmountInStock = amountInStock;
            ProductionCost = productionCost;
        }
    }
}