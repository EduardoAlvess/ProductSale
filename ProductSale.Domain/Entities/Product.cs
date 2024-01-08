using ProductSale.Domain.Utils;
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
            Description = description;
            AmountInStock = amountInStock;
            ProductionCost = productionCost;
        }

        public void Update(Product product)
        {
            Ensure.NotNull(product.Name, "The product name is required", nameof(product.Name));
            Ensure.NotNull(product.Description, "The product description is required", nameof(product.Description));
            Ensure.GreaterThanZero(product.Value, "The product value must be greather than 0", nameof(product.Value));
            Ensure.GreaterThanOrEqualToZero(product.AmountInStock, "The product stock must be greather or equal than 0", nameof(product.AmountInStock));
            Ensure.GreaterThanOrEqualToZero(product.ProductionCost, "The product production cost must be greather or equal than 0", nameof(product.ProductionCost));

            Name = product.Name;
            Value = product.Value;
            Description = product.Description;
            AmountInStock = product.AmountInStock;
            ProductionCost = product.ProductionCost;
        }

        public void RemoveFromStock(int quantityToRemove)
        {
            AmountInStock -= quantityToRemove;
        }

        public void Delete()
        {
            if (!IsDeleted)
            {
                IsDeleted = true;
            }
        }
    }
}
