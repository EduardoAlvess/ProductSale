namespace ProductSale.Core.Exceptions.OrderExceptions
{
    public class QuantityLowerThanZeroException : Exception
    {
        public QuantityLowerThanZeroException(string message) : base(message)
        {

        }

        public override string StackTrace => string.Empty;

        public override string ToString()
        {
            return Message;
        }
    }
}
