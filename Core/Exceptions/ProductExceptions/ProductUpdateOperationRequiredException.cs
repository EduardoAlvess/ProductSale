namespace ProductSale.Core.Exceptions.ProductExceptions
{
    public class ProductUpdateOperationRequiredException : Exception
    {
        public ProductUpdateOperationRequiredException(string message) : base(message)
        {

        }

        public override string StackTrace => string.Empty;

        public override string ToString()
        {
            return Message;
        }
    }
}
