namespace ProductSale.Domain.Utils
{
    public static class Ensure
    {
        public static void NotNull(object value, string message, string argumentName)
        {
            if (value is null)
            {
                throw new ArgumentNullException(message, argumentName);
            }
        }

        public static void GreaterThanOrEqualToZero(double value, string message, string argumentName)
        {
            if (value < 0)
            {
                throw new ArgumentException(message, argumentName);
            }
        }

        public static void GreaterThanZero(double value, string message, string argumentName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message, argumentName);
            }
        }
    }
}
