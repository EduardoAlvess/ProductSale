namespace ProductSale.Core.Exceptions
{
    public class UpdateOperationRequiredException : Exception
    {
        public UpdateOperationRequiredException(string message) : base(message)
        {

        }

        public override string StackTrace => string.Empty;

        public override string ToString()
        {
            return Message;
        }
    }
}
