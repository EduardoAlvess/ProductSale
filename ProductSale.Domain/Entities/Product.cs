using System.ComponentModel.DataAnnotations;

namespace ProductSale.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Value { get; private set; }
        public bool IsDeleted { get; private set; }
        public int AmountInStock { get; private set; }
        public string Description { get; private set; }
        public double ProductionCost { get; private set; }

        public Product(string name, double value, int amountInStock, string description, double productionCost)
        {
            Name = name;
            Value = value;
            AmountInStock = amountInStock;
            Description = description;
            ProductionCost = productionCost;
        }
    }
}
