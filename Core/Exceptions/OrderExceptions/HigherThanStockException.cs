namespace ProductSale.Core.Exceptions.OrderExceptions
{
    public class HigherThanStockException : Exception
    {
        public HigherThanStockException(string message) : base(message)
        {

        }

        public override string StackTrace => string.Empty;

        public override string ToString()
        {
            return Message;
        }
    {
    }
}
