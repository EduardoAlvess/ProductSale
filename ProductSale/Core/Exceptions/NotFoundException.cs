namespace ProductSale.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }

        public override string StackTrace => string.Empty;

        public override string ToString()
        {
            return Message;
        }
    }
}
