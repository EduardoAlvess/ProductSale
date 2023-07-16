namespace ProductSale.Core.Exceptions
{
    public class UpdatePathRequiredException : Exception
    {
        public UpdatePathRequiredException(string message) : base(message)
        {

        }

        public override string StackTrace => string.Empty;

        public override string ToString()
        {
            return Message;
        }
    }
}
