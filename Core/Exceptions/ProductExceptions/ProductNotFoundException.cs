namespace ProductSale.Core.Exceptions.ProductExceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message)
        {

        }

        public override string StackTrace => string.Empty;

        public override string ToString()
        {
            return Message;
        }
    }
}
