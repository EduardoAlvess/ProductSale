namespace ProductSale.Core.Exceptions.CustomerExceptions
{
    public class RegisterInvalidException : Exception
    {
        public RegisterInvalidException(string message) : base(message)
        {

        }

        public override string StackTrace => string.Empty;

        public override string ToString()
        {
            return Message;
        }
    }
}
