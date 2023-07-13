namespace ProductSale.Core.Exceptions
{
    public class UpdateValueRequiredException : Exception
    {
        public UpdateValueRequiredException(string message) : base(message)
        {

        }

        public override string StackTrace => string.Empty;

        public override string ToString()
        {
            return Message;
        }
    }
}
