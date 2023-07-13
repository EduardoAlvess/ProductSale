namespace ProductSale.Core.Exceptions.ProductExceptions
{
    public class ProductUpdateValueRequiredException : Exception
    {
        public ProductUpdateValueRequiredException(string message) : base(message)
        {

        }

        public override string StackTrace => string.Empty;

        public override string ToString()
        {
            return Message;
        }
    }
}
