namespace ProductSale.Core.Exceptions.ProductExceptions
{
    public class ProductUpdatePathRequiredException : Exception
    {
        public ProductUpdatePathRequiredException(string message) : base(message)
        {

        }

        public override string StackTrace => string.Empty;

        public override string ToString()
        {
            return Message;
        }
    }
}
