namespace ProductSale.DTOs.Product
{
    public class InputProductDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public int AmountInStock { get; set; }
        public string Description { get; set; }
        public double ProductionCost { get; set; }
    }
}
