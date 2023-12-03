namespace ProductSale.Aplication.UseCases
{
    public class UseCaseResult
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public UseCaseResult(bool success, string message = "")
        {
            Success = success;
            Message = message;
        }
    }

    public class UseCaseResult<T> : UseCaseResult
    {
        public UseCaseResult(T data, bool success, string message = "") : base(success, message)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }
}